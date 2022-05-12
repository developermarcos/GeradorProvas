using Apresentacao.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorProvas.ModuloQuestao
{
    public partial class TabelaQuestaoControl : UserControl
    {
        public TabelaQuestaoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia.Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia.Descricao", HeaderText = "Descrição. Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Pergunta", HeaderText = "Pergunta"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia.Serie", HeaderText = "Serie"}

            };

            return colunas;
        }

        public int ObtemNumeroQuestaoSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();
            foreach(var questao in questoes)
            {
                grid.Rows.Add(
                    questao.Numero, 
                    questao.Materia.Disciplina, 
                    questao.Materia.Descricao, 
                    questao.Pergunta,
                    questao.Materia.Serie);
            }
        }
    }
}
