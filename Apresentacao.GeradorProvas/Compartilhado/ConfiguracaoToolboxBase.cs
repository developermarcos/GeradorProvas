using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorProvas.Compartilhado
{
    internal abstract class ConfiguracaoToolboxBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }

        public abstract string TooltipFiltrar { get; }
        public abstract string TooltipGerarPdf { get; }

        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool FiltrarHabilitado { get { return false; } }
        public virtual bool PdfHabilitado { get { return false; } }

    }
}
