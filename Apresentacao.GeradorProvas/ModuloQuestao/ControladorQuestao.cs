using Apresentacao.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.ModuloQuestao;
using GeradorProvas.Compartilhado;
using Infra.GeradorProvas.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorProvas.ModuloQuestao
{
    internal class ControladorQuestao : ControladorBase
    {
        private TabelaQuestaoControl tabelaQuestao;
        private IRepositorioQuestao repositorioQuestao;
        private IRepositorioMateria repositorioMateria;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, IRepositorioMateria repositorioMateria)
        {
            this.repositorioQuestao=repositorioQuestao;
            this.repositorioMateria=repositorioMateria;
        }

        public override void Editar()
        {
            Questao questao = ObtemQuestaoSelecionada();

            if(questao == null)
            {
                MessageBox.Show("Selecione uma questão primeiro?", "Editar questão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Materia> Materias = repositorioMateria.SelecionarTodos();
            
            TelaCadastroQuestaoForm telaEdicao = new TelaCadastroQuestaoForm("Editar Questão", Materias);

            telaEdicao.Questao = questao;

            telaEdicao.GravarRegistro = repositorioQuestao.Editar;

            DialogResult resultado = telaEdicao.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarQuestoes();
        }

        public override void Excluir()
        {
            Questao questao = ObtemQuestaoSelecionada();

            if (questao == null)
            {
                MessageBox.Show("Selecione uma questão primeiro?", "Editar questão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show($"Deseja realmente excluir a questão ({questao.Pergunta})?", 
                "Excluir questão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questao);
                CarregarQuestoes();
            }
                
        }

        public override void Filtrar()
        {
            TelaFiltroQuestaoForm telaFiltro = new TelaFiltroQuestaoForm("Editar Questão");
            telaFiltro.ShowDialog();
        }

        public override void Inserir()
        {
            List<Materia>Materias = repositorioMateria.SelecionarTodos();

            if(Materias == null || Materias.Count == 0)
            {
                MessageBox.Show("Deve ser cadastrado uma matéria primeiro", "Inserir questão", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            
            TelaCadastroQuestaoForm telaCadastro = new TelaCadastroQuestaoForm("Inserir Questão", Materias);

            telaCadastro.GravarRegistro = repositorioQuestao.Inserir;

            DialogResult resultado = telaCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarQuestoes(); 
        }

        public override ConfiguracaoToolboxBase ObterConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxQuestao();
        }

        public override UserControl ObterListagem()
        {
            tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            if (questoes != null && questoes.Count > 0)
                tabelaQuestao.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {questoes.Count} materia(s)");
        }
        private Questao ObtemQuestaoSelecionada()
        {
            int numeroSelecionado = tabelaQuestao.ObtemNumeroQuestaoSelecionada();

            Questao questaoSelecionada = repositorioQuestao.SelecionarPorNumero(numeroSelecionado);

            return questaoSelecionada;
        }

    }
}
