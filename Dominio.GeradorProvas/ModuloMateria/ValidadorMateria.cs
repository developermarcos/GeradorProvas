

using FluentValidation;
using System.Collections.Generic;

namespace Dominio.GeradorProvas.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria(Materia materia, List<Materia> materias)
        {
            RuleFor(x => x.Disciplina)
                .NotEmpty().NotNull();

            RuleFor(x => x.Serie)
                .NotEmpty().NotNull();

            RuleFor(x => x.Descricao)
                .NotEmpty().NotNull();
            
            foreach(var item in materias)
            {
                if(materia.Numero != item.Numero)
                    RuleFor(x => x.Descricao).NotEqual(item.Descricao).WithMessage("Descrição não pode ser repetida no sistema");
            }
            
        }
    }
}
