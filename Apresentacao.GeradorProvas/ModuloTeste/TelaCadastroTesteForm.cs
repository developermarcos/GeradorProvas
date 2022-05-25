using Apresentacao.GeradorProvas;
using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloQuestao;
using Dominio.GeradorProvas.ModuloTeste;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorProvas.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        List<Questao> questoesCadastradas;
        private Teste teste;
        public TelaCadastroTesteForm(string nomeTela, List<Questao> questoesCadastradas)
        {
            InitializeComponent();

            Text = nomeTela;

            this.questoesCadastradas = questoesCadastradas;

            PopularTela();
        }

        public Teste Teste
        {
            get { return teste; }
            set
            {
                teste = value;
            }
        }

        private void PopularTela()
        {
            cBoxDiciplina.Items.Clear();

            foreach (int i in Enum.GetValues(typeof(DisciplinaEnum)))
                cBoxDiciplina.Items.Add((DisciplinaEnum)i);

            cBoxSerie.Items.Clear();

            foreach (int i in Enum.GetValues(typeof(SerieEnum)))
                cBoxSerie.Items.Add((SerieEnum)i);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            teste.Titulo = txtboxTitulo.Text;
            teste.Disciplina = (DisciplinaEnum)cBoxDiciplina.SelectedItem;
            teste.Serie = (SerieEnum)cBoxSerie.SelectedItem;
            teste.quantidadeQuestoes = (int)numericUpDownQuantidade.Value;
            teste.Questoes = new List<Questao>();

        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            List<Questao> questaos = ObterListaQuestoesComFiltro();
            qtdQuestoesExistentes.Text = $"{questaos.Count.ToString()} questões encontradas";
        }

        public List<Questao> ObterListaQuestoesComFiltro()
        {
            teste.Disciplina = (DisciplinaEnum)cBoxDiciplina.SelectedItem;
            teste.Serie = (SerieEnum)cBoxSerie.SelectedItem;

            try
            {
                List<Questao> questaosPorDisciplina = (List<Questao>)questoesCadastradas.FindAll(x => x.Materia.Disciplina == teste.Disciplina);

                List<Questao> questaosPorDiciplinaSerie = (List<Questao>)questaosPorDisciplina.FindAll(x => x.Materia.Serie == teste.Serie);

                return questaosPorDiciplinaSerie;
            }
            catch (Exception e)
            {
                return new List<Questao>();
            }
        }

        private void LimpaLabelQuantidadeQuestoes()
        {
            qtdQuestoesExistentes.Text = default;
        }

        private void cBoxDiciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaLabelQuantidadeQuestoes();
        }

        private void cBoxSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaLabelQuantidadeQuestoes();
        }
    }
}
