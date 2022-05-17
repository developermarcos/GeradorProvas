

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
                .GreaterThan(0)
                .WithMessage("Quantidade de questões não pode ser menor que zero");

        }
    }
}
