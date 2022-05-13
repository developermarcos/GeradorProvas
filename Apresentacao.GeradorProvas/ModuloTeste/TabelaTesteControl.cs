using Apresentacao.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloTeste;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorProvas.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        private DataGridViewColumn[] ObterColunas()
        {

            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Numero"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Titulo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Serie"},

            };

            return colunas;
        }

        public int ObtemNumeroTesteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();
            foreach (var teste in testes)
            {
                grid.Rows.Add(
                    teste.Numero,
                    teste.Titulo,
                    teste.Disciplina,
                    teste.Serie);
            }
        }

    }
}
