using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class InvestorValidator: AbstractValidator<Investor>
    {
        public InvestorValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Cpf)
                .NotNull()
                .WithMessage("O cpf não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O cpf não pode ser vazio.")

                .MinimumLength(11)
                .WithMessage("O cpf deve ter 11 caracteres.")

                .MaximumLength(11)
                .WithMessage("O nome deve ter 11 caracteres.");

            RuleFor(x => x.IdUser)
              .NotNull()
              .WithMessage("O usuário não pode ser nulo.")

              .NotEmpty()
              .WithMessage("O usuário não pode ser vazio.")

              .GreaterThan(0)
              .WithMessage("O usuário está inválido.");
    }
    }
}
