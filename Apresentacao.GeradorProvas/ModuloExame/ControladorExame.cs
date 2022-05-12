using GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorProvas.ModuloExame
{
    internal class ControladorExame : ControladorBase
    {
        public override void Editar()
        {
            TelaCadastroExameForm telaEdicao = new TelaCadastroExameForm("Editar exame");
            telaEdicao.ShowDialog();
        }

        public override void Excluir()
        {
            MessageBox.Show("Deseja realmente excluir esse exame?", "Excluir exame", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public override void Filtrar()
        {
            TelaFiltroExameForm telaFiltro = new TelaFiltroExameForm("Editar exame");
            telaFiltro.ShowDialog();
        }

        public override void Inserir()
        {
            TelaCadastroExameForm telaCadastro = new TelaCadastroExameForm("Cadastro exame");
            telaCadastro.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObterConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxExame();
        }

        public override UserControl ObterListagem()
        {
            var tabelaExames = new TabelaExameControl();

            //CarregarMaterias();

            return tabelaExames;
        }
    }
}
