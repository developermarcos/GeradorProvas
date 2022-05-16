

using FluentValidation;
using System.Collections.Generic;

namespace Dominio.GeradorProvas.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.Disciplina)
                .NotEmpty().NotNull();

            RuleFor(x => x.Serie)
                .NotEmpty().NotNull();

            RuleFor(x => x.Descricao)
                .NotEmpty().NotNull();
        }
    }
}
