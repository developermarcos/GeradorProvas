using Apresentacao.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using Dominio.GeradorProvas.ModuloQuestao;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorProvas.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        public List<Materia> Materias;
        private Questao questao;
        public TelaCadastroQuestaoForm(string nomeTela, List<Materia> materias)
        {
            InitializeComponent();

            Text = nomeTela;

            this.Materias = materias;

            PreencherTela();
        }

        private void PreencherTela()
        {
            cBoxMateria.Items.Clear();
            foreach (var item in Materias)
                cBoxMateria.Items.Add(item);
        }

        public Questao Questao 
        {
            get { return questao; }
            set 
            { 
                questao = value;
                cBoxMateria.SelectedItem = questao.Materia;
                textBoxDescricao.Text = questao.Pergunta;
                ListarAlternativas();
            } 
        }
        private void ListarAlternativas()
        {
            listaAlternativas.Items.Clear();

            if(questao.Alternativas != null && questao.Alternativas.Count > 0)
                foreach (var item in questao.Alternativas)
                    listaAlternativas.Items.Add(item);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = new Alternativa();

            if (!textBoxAlternativa.Text.Any()) { 
                MessageBox.Show("Informe a descrição da alternativa primeiro", "Adicionar alternativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            alternativa.Descricao = textBoxAlternativa.Text;

            if (rBtnVerdade.Checked == true)
                alternativa.EstaCorreta = true;

            questao.Alternativas.Add(alternativa);
            ListarAlternativas();
            textBoxAlternativa.Text = null;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Alternativa alternativa = (Alternativa)listaAlternativas.SelectedItem;

            questao.Alternativas.Remove(alternativa);

            ListarAlternativas();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Materia = (Materia)cBoxMateria.SelectedItem;
            questao.Pergunta = textBoxDescricao.Text;

            var resultadoValidacao = GravarRegistro(Questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

    }
}
