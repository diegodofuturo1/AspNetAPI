using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class ContributionValidator: AbstractValidator<Contribution>
    {
        public ContributionValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.IdInvestor)
                .NotNull()
                .WithMessage("O investidor não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O investidor não pode ser vazio.")

                .GreaterThan(0)
                .WithMessage("O investidor está inválido.");

            RuleFor(x => x.Value)
                .NotNull()
                .WithMessage("O valor do aporte não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O valor do aporte não pode ser vazio.")

                .GreaterThan(0)
                .WithMessage("O valor do aporte não pode ser nulo ou negativo.")

                .Must(value => value % 500 == 0)
                .WithMessage("O valor do aporte tem que ser um multiplo de 500.");
        }
    }
}
