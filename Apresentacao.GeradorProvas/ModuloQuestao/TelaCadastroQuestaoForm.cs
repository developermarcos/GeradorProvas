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

            int quantidadeAlternativasVerdadeiras = 0;
            foreach(var item in questao.Alternativas)
            {
                if (item.EstaCorreta)
                    quantidadeAlternativasVerdadeiras++;
            }

            if(quantidadeAlternativasVerdadeiras != 1)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("A alternativa deve conter apenas uma alternativa verdadeira");
                DialogResult = DialogResult.None;
                return;
            }

            var resultadoValidacao = GravarRegistro(Questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        private void cBoxDiciplina_Leave(object sender, EventArgs e)
        {
            AlternarCBoxMaterias();
        }

        private void cBoxDiciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlternarCBoxMaterias();
        }
        
        private void AlternarCBoxMaterias()
        {
            if (cBoxDiciplina.SelectedItem != null)
            {
                cBoxMateria.SelectedItem =  null;

                cBoxMateria.Items.Clear();

                DiciplinaEnum Disciplina = (DiciplinaEnum)cBoxDiciplina.SelectedItem;

                List<Materia> materiaFiltrada = Materias.FindAll(x => x.Disciplina == Disciplina);

                foreach (var item in materiaFiltrada)
                {
                    cBoxMateria.Items.Add(item);
                }
            }
        }
    }
}
