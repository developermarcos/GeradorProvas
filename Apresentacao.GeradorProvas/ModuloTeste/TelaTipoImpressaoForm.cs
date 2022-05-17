using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao.GeradorProvas.ModuloTeste
{
    public partial class TelaTipoImpressaoForm : Form
    {
        public TelaTipoImpressaoForm()
        {
            InitializeComponent();
        }

        public bool ImpressaoGabarito()
        {
            if(rBtnGabarito.Checked == true)
                return true;

            return false;
        }
    }
}
