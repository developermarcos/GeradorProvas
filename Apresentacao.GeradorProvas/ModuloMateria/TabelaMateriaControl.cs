using Apresentacao.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorProvas.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        private AgrupamentoMateriaEnum tipoAgrupamento;
        public TabelaMateriaControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Numero"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descricao"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Serie"},

            };

            return colunas;
        }

        public int ObtemNumeroCompromissoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.DataSource = materias;
        }
    }
}
