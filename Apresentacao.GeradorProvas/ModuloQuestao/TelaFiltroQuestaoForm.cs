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
    public partial class TelaFiltroQuestaoForm : Form
    {
        public TelaFiltroQuestaoForm(string nomeTela)
        {
            InitializeComponent();

            Text = nomeTela;
        }
    }
}
