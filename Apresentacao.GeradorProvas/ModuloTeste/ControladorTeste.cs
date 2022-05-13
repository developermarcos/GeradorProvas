using Apresentacao.GeradorProvas;
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
        private IRepositorioMateria repositorioMateria;
        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioQuestao repositorioQuestao, IRepositorioMateria repositorioMateria)
        {
            this.repositorioTeste=repositorioTeste;
            this.repositorioQuestao=repositorioQuestao;
            this.repositorioMateria=repositorioMateria;
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
        }

        public void GerarPDF()
        {
            Teste teste = ObtemTesteSelecionado();

            if (teste == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Excluir teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show($"Gerar pdf do teste ({teste.Titulo})?",
                "Gerar PDF", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public override void Inserir()
        {
            TelaCadastroTesteForm telaCadastro = new TelaCadastroTesteForm("Cadastro exame");

            Teste teste = new Teste();

            telaCadastro.Teste = teste;


            DialogResult resultado = telaCadastro.ShowDialog();
            if(DialogResult.OK == resultado)
            {
                List<Questao> questoesFiltradas = ObterListaQuestoesComFiltros(telaCadastro.Teste);

                if(questoesFiltradas == null || questoesFiltradas.Count == 0)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("Nenhuma questao encontrada");
                    return;
                }

                telaCadastro.Teste.Questoes = ObterQuestoesRandomicas(questoesFiltradas, telaCadastro.Teste.quantidadeQuestoes);

                var resultadoValidacao = repositorioTeste.Inserir(telaCadastro.Teste);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                }
                CarregarTestes();
            }


        }

        private List<Questao> ObterQuestoesRandomicas(List<Questao> questoesFiltradas, int quantidadeQuestoes)
        {
            if (questoesFiltradas.Count < quantidadeQuestoes)
                return questoesFiltradas;

            List<Questao> questaoRandomicas = new List<Questao>();

            Random numero = new Random();

            while (questaoRandomicas.Count != quantidadeQuestoes)
            {
                int ranNum = numero.Next(0, (quantidadeQuestoes - 1));

                if(questaoRandomicas.Exists(x => x != questoesFiltradas[ranNum]))
                    questaoRandomicas.Add(questoesFiltradas[ranNum]);
            }

            return questaoRandomicas;
        }

        private List<Questao> ObterListaQuestoesComFiltros(Teste Teste)
        {
            try { 
                List<Questao> questaos = repositorioQuestao.SelecionarTodos();

                List<Questao> questaosPorDisciplina = (List<Questao>)questaos.FindAll(x => x.Materia.Disciplina == Teste.Disciplina);

                List<Questao> questaosPorDiciplinaSerie = (List<Questao>)questaosPorDisciplina.FindAll(x => x.Materia.Serie == Teste.Serie);

                return questaosPorDiciplinaSerie;
            }
            catch(Exception e)
            {
                return new List<Questao>();
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
