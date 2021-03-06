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
        private List<Alternativa> Alternativas { get; set; }
        public TelaCadastroQuestaoForm(string nomeTela, List<Materia> materias)
        {
            InitializeComponent();

            Text = nomeTela;

            this.Materias = materias;
            
            questao = new Questao();

            Alternativas = new List<Alternativa>();

            PreencherTela();
        }

        private void PreencherTela()
        {
            cBoxDiciplina.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(DisciplinaEnum)))
                cBoxDiciplina.Items.Add((DisciplinaEnum)i);

        }

        public Questao Questao 
        {
            get { return questao; }
            set 
            { 
                questao = value;
                cBoxDiciplina.SelectedItem = questao.Materia.Disciplina;
                PopularMateriaPorDisciplinaSelecionada();
                textBoxDescricao.Text = questao.Pergunta;
                txtBoxNumeroQuestao.Text = questao.Numero.ToString();
                cBoxMateria.SelectedItem = (Materia)questao.Materia;

                foreach (var item in questao.Alternativas)
                    Alternativas.Add(item);

                ListarAlternativas();
                
            } 
        }
        private void ListarAlternativas()
        {
            listaAlternativas.Items.Clear();

            if(Alternativas != null && Alternativas.Count > 0)
                foreach (var item in Alternativas)
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

            Alternativas.Add(alternativa);

            ListarAlternativas();

            textBoxAlternativa.Text = null;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Alternativa alternativaSelecionada = (Alternativa)listaAlternativas.SelectedItem;

            Alternativas.Remove(alternativaSelecionada);

            ListarAlternativas();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Questao novaQuestao = new Questao();

            novaQuestao.Numero = questao.Numero;
            novaQuestao.Pergunta = textBoxDescricao.Text;
            Materia materia = (Materia)cBoxMateria.SelectedItem;
            novaQuestao.Materia = materia;
            novaQuestao.Alternativas = Alternativas;

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

                DisciplinaEnum Disciplina = (DisciplinaEnum)cBoxDiciplina.SelectedItem;

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
