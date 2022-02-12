using FluentValidation;
using Supervaga.Domain.Ads.Commands;

namespace Supervaga.Domain.Ads.Validators.Commands
{
    public class CreateAdCommandValidator : AbstractValidator<CreateAdCommand>
    {
        public CreateAdCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                    .WithMessage("O Título é obrigatório")
                .MinimumLength(6)
                    .WithMessage("O Título deve ter no mínimo 6 caracteres");
            RuleFor(x => x)
                .NotNull()
                    .WithMessage("O Usuário é obrigatório")
                .Must(x => x.UserId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Usuário é inválido");
            RuleFor(x => x.Description)
                .NotNull()
                    .WithMessage("A Descrição é obrigatória")
                .MinimumLength(15)
                    .WithMessage("A Descrição deve ter no mínimo 15 caracteres");
            RuleFor(x => x.Category)
                .NotNull().WithMessage("A categoria é obrigatória");
            RuleFor(x => x.Requirements)
                .NotNull()
                    .WithMessage("Os Requisitos são obrigatórios")
                .NotEmpty()
                    .WithMessage("Os Requisitos devem ser preenchidos");
            RuleFor(x => x.Advantages)
                .NotNull()
                    .WithMessage("As Vantagens são obrigatórias")
                .NotEmpty()
                    .WithMessage("As Vantagens devem ser preenchidas");
            RuleFor(x => x.ExpiresAt)
                .GreaterThan(x => x.CreatedAt)
                    .WithMessage("A Data de Expiração deve ser válida");
            RuleFor(x => x.SalaryOffer)
                .GreaterThan(0)
                    .WithMessage("A Oferta deverá ser maior que 0,00 MT");
        }
    }
}