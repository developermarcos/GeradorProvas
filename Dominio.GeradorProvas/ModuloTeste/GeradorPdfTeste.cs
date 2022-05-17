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
        public GeradorPdfTeste(string caminho, Teste teste, bool impressaoGabarito)
        {
            this.caminho=caminho;

            this.ImpressaoGabarito=impressaoGabarito;

            Teste=teste;

            Letras.Add(1, "A");
            Letras.Add(2, "B");
            Letras.Add(3, "C");
            Letras.Add(4, "D");
            Letras.Add(5, "E");
            Letras.Add(6, "F");
            Letras.Add(7, "G");
            Letras.Add(8, "H");
            Letras.Add(9, "I");
            Letras.Add(10, "J");
        }

        private bool ImpressaoGabarito { get; set; }

        public string caminho { get; set;}

        IDictionary<int, string> Letras = new Dictionary<int, string>();

        public Teste Teste { get; set; }

        public void GerarPdf()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);

            PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            CriaCabecalhoImpressao(doc);

            CriaIdentificacaoImpressao(doc);

            int numeroQuestao = 1;

            foreach (Questao item in Teste.Questoes)
            {
                CriaQuestao(doc, numeroQuestao, item);

                numeroQuestao++;
            }

            doc.Close();


        }

        private void CriaQuestao(Document doc, int numeroQuestao, Questao item)
        {
            Paragraph paragrafo = new Paragraph();

            string questao = numeroQuestao.ToString()+"- "+item.Pergunta+"\n";

            int posicaoQuestao = 1;
            foreach (var Alternativa in item.Alternativas)
            {
                if(ImpressaoGabarito && Alternativa.EstaCorreta)
                    questao += "  "+Letras[posicaoQuestao]+") "+Alternativa.Descricao+" - Correta"+"\n";
                else
                    questao += "  "+Letras[posicaoQuestao]+") "+Alternativa.Descricao+"\n";
                posicaoQuestao++;
            }
            questao += "\n";

            paragrafo.Add(questao);

            doc.Add(paragrafo);
        }

        private void CriaCabecalhoImpressao(Document doc)
        {
            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.TIMES_ROMAN, 32);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add(Teste.Titulo+"\n\n");
            doc.Add(titulo);
        }

        private void CriaIdentificacaoImpressao(Document doc)
        {
            Paragraph Identificacao = new Paragraph();
            Identificacao.Font = new Font(Font.FontFamily.TIMES_ROMAN, 18);
            Identificacao.Alignment = Element.ALIGN_LEFT;
            if (ImpressaoGabarito)
                Identificacao.Add("GABARITO\n");
            Identificacao.Add("Aluno: \n");
            Identificacao.Add("Série: "+Teste.Serie+"\n\n\n");
            doc.Add(Identificacao);
        }
    }
}
