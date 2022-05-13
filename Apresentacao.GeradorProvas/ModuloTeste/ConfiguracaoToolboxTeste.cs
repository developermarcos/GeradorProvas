using GeradorProvas.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorProvas.ModuloTeste
{
    internal class ConfiguracaoToolboxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Listagem Exames";

        public override string TooltipInserir => "Cadastrar exame";

        public override string TooltipEditar => "Editar exame";

        public override string TooltipExcluir => "Excluir exame";

        public override string TooltipFiltrar => "Filtrar exame";

        public override string TooltipGerarPdf => "Gerar PDF";

        public override bool FiltrarHabilitado => true;

        public override bool EditarHabilitado => false;

        public override bool PdfHabilitado => true;
    }
}
