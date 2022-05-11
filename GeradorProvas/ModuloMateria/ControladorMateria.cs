using GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorProvas.ModuloMateria
{
    internal class ControladorMateria : ControladorBase
    {
        private TabelaMateriaControl tabelaMateria;
        public override void Editar()
        {
            TelaCadastroMateriaForm telaCadastro = new TelaCadastroMateriaForm("Editar Matéria");
            telaCadastro.ShowDialog();
        }

        public override void Excluir()
        {
            MessageBox.Show("Deseja realmente excluir essa matéria?", "Excluir matéria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public override void Filtrar()
        {
            TelaFiltroMateriaForm telaFiltro = new TelaFiltroMateriaForm("Filtrar Matérias");
            telaFiltro.ShowDialog();
        }

        public override void Inserir()
        {
            TelaCadastroMateriaForm telaCadastro = new TelaCadastroMateriaForm("Cadastrar Matéria");
            telaCadastro.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObterConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        public override UserControl ObterListagem()
        {
            tabelaMateria = new TabelaMateriaControl();

            //CarregarMaterias();

            return tabelaMateria;
        }
    }
}
