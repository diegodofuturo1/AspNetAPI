using System;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class RevenueValidator: AbstractValidator<Revenue>
    {
        public RevenueValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.IdEnterprise)
                .NotNull()
                .WithMessage("O Empreendimento não pode ser nula.")

                .NotEmpty()
                .WithMessage("O Empreendimento não pode ser vazia.")

                .GreaterThan(0)
                .WithMessage("O Empreendimento é inválida ou não existe.");


            RuleFor(x => x.IdContribution)
                .NotNull()
                .WithMessage("A contribuição não pode ser nula.")

                .NotEmpty()
                .WithMessage("A contribuição não pode ser vazia.")

                .GreaterThan(0)
                .WithMessage("A contribuição é inválida ou não existe.");
        }
    }
}
