using Apresentacao.GeradorProvas;
using Dominio.GeradorProvas;
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
            
            questao = new Questao();

            PreencherTela();
        }

        private void PreencherTela()
        {
            cBoxDiciplina.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(DiciplinaEnum)))
                cBoxDiciplina.Items.Add((DiciplinaEnum)i);

        }

        public Questao Questao 
        {
            get { return questao; }
            set 
            { 
                questao = value;
                cBoxDiciplina.SelectedItem = questao.Materia.Disciplina;
                PopularMateriaPorDisciplinaSelecionada();
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
            Questao novaQuestao = new Questao();

            novaQuestao.Numero = questao.Numero;
            novaQuestao.Pergunta = textBoxDescricao.Text;
            Materia materia = (Materia)cBoxMateria.SelectedItem;
            novaQuestao.Materia = materia;
                novaQuestao.Alternativas = questao.Alternativas;

            var resultadoValidacao = GravarRegistro(novaQuestao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        private void cBoxDiciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopularMateriaPorDisciplinaSelecionada();
        }

        private void PopularMateriaPorDisciplinaSelecionada()
        {
            if (cBoxDiciplina.SelectedItem != null)
            {
                cBoxMateria.SelectedItem =  null;

                cBoxMateria.Items.Clear();

                DiciplinaEnum Disciplina = (DiciplinaEnum)cBoxDiciplina.SelectedItem;

                List<Materia> materiaFiltrada = Materias.FindAll(x => x.Disciplina == Disciplina);

                if (materiaFiltrada == null || materiaFiltrada.Count == 0)
                {
                    MessageBox.Show($"Nenhuma materia encontrada para a diciplina {Disciplina}", "Lista de matérias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                foreach (var item in materiaFiltrada)
                {
                    cBoxMateria.Items.Add(item);
                }
            }
        }
    }
}
