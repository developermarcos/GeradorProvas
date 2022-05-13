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
        private Teste teste;
        public TelaCadastroTesteForm(string nomeTela)
        {
            InitializeComponent();

            Text = nomeTela;

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

            foreach (int i in Enum.GetValues(typeof(DiciplinaEnum)))
                cBoxDiciplina.Items.Add((DiciplinaEnum)i);

            cBoxSerie.Items.Clear();

            foreach (int i in Enum.GetValues(typeof(SerieEnum)))
                cBoxSerie.Items.Add((SerieEnum)i);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            teste.Titulo = txtboxTitulo.Text;
            teste.Disciplina = (DiciplinaEnum)cBoxDiciplina.SelectedItem;
            teste.Serie = (SerieEnum)cBoxSerie.SelectedItem;
            teste.quantidadeQuestoes = (int)numericUpDownQuantidade.Value;
            teste.Questoes = new List<Questao>();

        }
    }
}
