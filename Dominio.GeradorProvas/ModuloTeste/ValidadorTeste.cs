

using FluentValidation;

namespace Dominio.GeradorProvas.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Disciplina)
                .NotEmpty().NotNull();

            RuleFor(x => x.Serie)
                .NotEmpty().NotNull();

            RuleFor(x => x.Questoes.Count)
                .GreaterThan(1)
                .WithMessage("Quantidade mínima de questões deve ser maior que 1");

        }
    }
}
