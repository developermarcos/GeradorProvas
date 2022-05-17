using Apresentacao.GeradorProvas;
using Apresentacao.GeradorProvas.ModuloTeste;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.ModuloQuestao;
using Dominio.GeradorProvas.ModuloTeste;
using GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeradorProvas.ModuloTeste
{
    internal class ControladorTeste : ControladorBase
    {
        private IRepositorioTeste repositorioTeste;
        private IRepositorioQuestao repositorioQuestao;
        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste=repositorioTeste;
            this.repositorioQuestao=repositorioQuestao;
        }

        public override void Editar()
        {
        }

        public override void Excluir()
        {
            Teste teste = ObtemTesteSelecionado();

            if(teste == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Excluir teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show($"Deseja realmente excluir o teste ({teste.Titulo})?", 
                "Excluir exame", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(teste);
                CarregarTestes();
            }
            
        }

        public override void Filtrar()
        {
            string texto = Microsoft.VisualBasic.Interaction.InputBox("Your Message", "Titulo", "Default Response");
        }

        public void Duplicar()
        {
            Teste testeSelecionado = ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Gerar PDF de teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string texto = Microsoft.VisualBasic.Interaction.InputBox("Informe o novo título", "Titulo", "");

            if(texto != "")
            {
                Teste novoTeste = new Teste();

                novoTeste.Titulo = texto;
                novoTeste.quantidadeQuestoes = testeSelecionado.quantidadeQuestoes;
                novoTeste.Serie = testeSelecionado.Serie;
                novoTeste.Disciplina = testeSelecionado.Disciplina;
                novoTeste.Questoes = testeSelecionado.Questoes;

                var resultadoValidacao = repositorioTeste.Inserir(novoTeste);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    Duplicar();
                }

                CarregarTestes();
            }

            
        }

        public void GerarPDF()
        {
            
            Teste teste = ObtemTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Gerar PDF de teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TelaTipoImpressaoForm telaTipoImpressao = new TelaTipoImpressaoForm();

            if(telaTipoImpressao.ShowDialog() == DialogResult.OK)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pastaSelecioanda = saveFileDialog.FileName;

                        GeradorPdfTeste geradorPdf = new GeradorPdfTeste(pastaSelecioanda, teste, telaTipoImpressao.ImpressaoGabarito());

                        geradorPdf.GerarPdf();
                    }
                }
            }
        }

        public override void Inserir()
        {
            TelaCadastroTesteForm telaCadastro = new TelaCadastroTesteForm("Cadastro exame", repositorioQuestao.SelecionarTodos());

            Teste teste = new Teste();

            telaCadastro.Teste = teste;


            DialogResult resultado = telaCadastro.ShowDialog();

            if(DialogResult.OK == resultado)
            {
                List<Questao> questoesFiltradas = telaCadastro.ObterListaQuestoesComFiltro();

                if(questoesFiltradas == null || questoesFiltradas.Count == 0)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Nenhuma questao encontrada");
                    return;
                }

                telaCadastro.Teste.Questoes = repositorioQuestao.ObterQuestoesRandomicas(questoesFiltradas, telaCadastro.Teste.quantidadeQuestoes);

                var resultadoValidacao = repositorioTeste.Inserir(telaCadastro.Teste);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    Inserir();
                }
                CarregarTestes();
            }


        }

        public override ConfiguracaoToolboxBase ObterConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }

        public override UserControl ObterListagem()
        {
            tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            if (testes != null && testes.Count > 0)
                tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {testes.Count} materia(s)");
        }

        private Teste ObtemTesteSelecionado()
        {
            int numeroSelecionado = tabelaTeste.ObtemNumeroTesteSelecionado();

            var testeSelecionado = repositorioTeste.SelecionarPorNumero(numeroSelecionado);

            return testeSelecionado;
        }
    }
}
