using GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorProvas.ModuloMateria
{
    internal class ConfiguracaoToolboxMateria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Listagem Materias";

        public override string TooltipInserir => "Inserir materia";

        public override string TooltipEditar => "Editar materia";

        public override string TooltipExcluir => "Excluir materia";

        public override string TooltipFiltrar => "Filtrar materias";

        public override bool InserirHabilitado { get { return true; } }

        public override bool EditarHabilitado { get { return true; } }

        public override bool ExcluirHabilitado { get { return true; } }

        public override bool FiltrarHabilitado { get { return true; } }

    }
}
