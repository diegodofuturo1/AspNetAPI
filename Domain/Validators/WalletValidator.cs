using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class WalletValidator: AbstractValidator<Wallet>
    {
        public WalletValidator()
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
                .WithMessage("O investidor é inválido ou não existe.");

            //RuleFor(x => x.Value)
            //    .NotNull()
            //    .WithMessage("O valor não pode ser nulo.")

            //    .NotEmpty()
            //    .WithMessage("O valor não pode ser vazio.")

            //    .GreaterThan(0)
            //    .WithMessage("O valor não pode ser nulo ou negativo.");
        }
    }
}
