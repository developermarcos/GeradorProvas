
using Dominio.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloMateria;
using FluentValidation;
using Infra.GeradorProvas.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace Infra.GeradorProvas.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioEmArquivoBase<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivo(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
    }
}
