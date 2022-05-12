using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.GeradorProvas.ModuloQuestao
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Pergunta)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Materia)
                .NotEmpty()
                .NotNull();
            RuleForEach(x => x.Alternativas).SetValidator(new ValidadorAlternativa());
        }
    }
}
