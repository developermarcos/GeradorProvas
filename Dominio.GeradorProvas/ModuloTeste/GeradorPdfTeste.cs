using Dominio.GeradorProvas.ModuloQuestao;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Dominio.GeradorProvas.ModuloTeste
{
    public class GeradorPdfTeste
    {
        public GeradorPdfTeste(string caminho, Teste teste)
        {
            this.caminho=caminho;
            Teste=teste;
        }

        public string caminho { get; set;}
        public Teste Teste { get; set; }

        public void GerarPdf()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);

            PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add(Teste.Titulo+"\n\n\n");
            doc.Add(titulo);

            
            int numeroQuestao = 1;
            foreach(Questao item in Teste.Questoes)
            {
                Paragraph paragrafo = new Paragraph();
                string questao = numeroQuestao.ToString()+"- "+item.Pergunta+"\n";

                foreach(var Alternativa in item.Alternativas)
                {
                    questao += "-"+Alternativa.Descricao+"\n";
                }
                paragrafo.Add(questao);
                doc.Add(paragrafo);

                numeroQuestao++;
            }

            doc.Close();

            ProcessStartInfo info = new ProcessStartInfo(caminho);
            System.Diagnostics.Process.Start(caminho);

        }
    }
}
