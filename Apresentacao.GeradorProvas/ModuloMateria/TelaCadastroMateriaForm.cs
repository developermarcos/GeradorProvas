using Apresentacao.GeradorProvas;
using Dominio.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
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

namespace GeradorProvas.ModuloMateria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        private Materia materia;
        public TelaCadastroMateriaForm(string nomeTela)
        {
            InitializeComponent();
            Text = nomeTela;
            PreencheTela();
        }
        public Materia Materia
        {
            get { return materia; }
            set 
            { 
                materia = value;
                cBoxDiciplina.SelectedItem = (DiciplinaEnum)materia.Disciplina;
                cBoxSerie.SelectedItem = (SerieEnum)materia.Serie;
                txtboxMateria.Text =  materia.Descricao;
            }
        }
        public void PreencheTela()
        {
            cBoxDiciplina.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(DiciplinaEnum)))
                cBoxDiciplina.Items.Add((DiciplinaEnum)i);

            cBoxSerie.Items.Clear();
            foreach (int i in Enum.GetValues(typeof(SerieEnum)))
                cBoxSerie.Items.Add((SerieEnum)i);
        }
        public Func<Materia, ValidationResult> GravarRegistro { get; set; }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.Disciplina = (DiciplinaEnum)cBoxDiciplina.SelectedItem;
            materia.Serie = (SerieEnum)cBoxSerie.SelectedItem;
            materia.Descricao = txtboxMateria.Text;

            var resultadoValidacao = GravarRegistro(Materia);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
