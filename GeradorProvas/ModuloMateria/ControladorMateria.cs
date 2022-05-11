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
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Filtrar()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            TelaCadastroMateriaForm telaCadastro = new TelaCadastroMateriaForm();
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
