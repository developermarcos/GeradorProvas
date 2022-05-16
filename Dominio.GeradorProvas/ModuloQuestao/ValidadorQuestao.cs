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
        public ValidadorQuestao(Questao questao, List<Questao> questoes)
        {
            RuleFor(x => x.Pergunta)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Materia)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Alternativas.Count)
                .NotEmpty()
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Questão necessita de pelo menos 2 alternativas cadastradas");
        }

    }
}
