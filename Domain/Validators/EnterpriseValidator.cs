using System;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class EnterpriseValidator: AbstractValidator<Enterprise>
    {
        public EnterpriseValidator()
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

            RuleFor(x => x.IdBuilder)
                .NotNull()
                .WithMessage("A construtora não pode ser nula.")

                .NotEmpty()
                .WithMessage("A construtora não pode ser vazia.")

                .GreaterThan(0)
                .WithMessage("A construtura é inválida ou não existe.");

            RuleFor(x => x.Value)
                .NotNull()
                .WithMessage("O valor não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O valor não pode ser vazio.")

                .GreaterThan(0)
                .WithMessage("O valor não pode ser nulo ou negativo.");

            RuleFor(x => x.ProfitabilityPerYear)
                .NotNull()
                .WithMessage("A rentabilidade anual não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A rentabilidade anual segmento não pode ser vazio.")
                
                .GreaterThan((short)0)
                .WithMessage("A rentabilidade anual não pode ser nulo ou negativo.");

            RuleFor(x => x.TermInMonths)
                .NotNull()
                .WithMessage("O prazo em meses não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O prazo em meses não pode ser vazio.")

                .GreaterThan(0)
                .WithMessage("O prazo em meses não pode ser nulo ou negativo.");

            RuleFor(x => x.PaymentType)
                .NotNull()
                .WithMessage("O tipo de pagamento não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O tipo de pagamento não pode ser vazio.")

                .IsInEnum()
                .WithMessage("tipo de pagamento é inválido ou não existe.");

        }
    }
}
