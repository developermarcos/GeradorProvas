using Dominio.GeradorProvas.Compartilhado;
using Dominio.GeradorProvas.ModuloMateria;
using FluentValidation;
using FluentValidation.Results;
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

        public override ValidationResult Inserir(Materia novoRegistro)
        {
            bool nomeJaCadastrado = dataContext.Materias.Any(x => x.Descricao.ToUpper() == novoRegistro.Descricao.ToUpper());

            if (nomeJaCadastrado)
            {
                ValidationResult validadorNome = new ValidationResult();

                validadorNome.Errors.Add(new ValidationFailure("", "Registro não inserido, matéria ja cadastrada."));

                return validadorNome;
            }

            return base.Inserir(novoRegistro);
        }

        public override ValidationResult Editar(Materia registro)
        {
            bool nomeJaCadastrado = dataContext.Materias.Any(x => 
                x.Descricao.ToUpper() == registro.Descricao.ToUpper()
                && x.Numero != registro.Numero);

            if (nomeJaCadastrado)
            {
                ValidationResult validadorNome = new ValidationResult();

                validadorNome.Errors.Add(new ValidationFailure("", "Registro não editado, descrição da matéria ja utilizada."));

                return validadorNome;
            }

            return base.Editar(registro);
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
