using GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorProvas.ModuloQuestao
{
    internal class ConfiguracaoToolboxQuestao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Listagem de Questões";

        public override string TooltipInserir => "Cadastrar questão";

        public override string TooltipEditar => "Editar questão";

        public override string TooltipExcluir => "Excluir questão";

        public override string TooltipFiltrar => "Filtrar questão";

        public override string TooltipGerarPdf => "Gerar PDF";

        public override bool FiltrarHabilitado { get { return true; } }
    }
}
