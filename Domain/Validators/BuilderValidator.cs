using System;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class BuilderValidator: AbstractValidator<Builder>
    {
        public BuilderValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.About)
                .NotNull()
                .WithMessage("Sobre a empresa não pode ser nula.")

                .NotEmpty()
                .WithMessage("Sobre a empresa não pode ser vazia.")

                .MinimumLength(6)
                .WithMessage("Sobre a empresa deve ter no mínimo 6 caracteres.")

                .MaximumLength(1000)
                .WithMessage("Sobre a empresa deve ter no máximo 1000 caracteres.");

            RuleFor(x => x.Cnpj)
                .NotNull()
                .WithMessage("O cnpj não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O cnpj não pode ser vazio.")

                .MinimumLength(14)
                .WithMessage("O cnpj deve ter 14 caracteres.")

                .MaximumLength(14)
                .WithMessage("O cnpj deve ter 14 caracteres.")

                .Matches(@"^\d{14}$")
                .WithMessage("O cnpj informado não é válido.");

            RuleFor(x => x.Segment)
                .NotNull()
                .WithMessage("O segmento não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O segmento não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O segmento deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O segmento deve ter no máximo 80 caracteres.");

            RuleFor(x => x.FoundationDate)
                .NotNull()
                .WithMessage("O data fundação não pode ser nula.")

                .NotEmpty()
                .WithMessage("O data fundação não pode ser vazia.")
                
                .LessThan(DateTime.Now)
                .WithMessage("O data fundação não pode estar no futuro.");
        }
    }
}
