using FluentValidation;
using Supervaga.Domain.Ads.Commands;

namespace Supervaga.Domain.Ads.Validators.Commands
{
    public class UpdateAdCommandValidator : AbstractValidator<UpdateAdCommand>
    {
        public UpdateAdCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("Id da vaga é inválido");
            RuleFor(x => x)
                .Must(x => x.UserId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Usuário é inválido");
            RuleFor(x => x.Title)
                .MinimumLength(6)
                    .WithMessage("O Título deve ter no mínimo 6 caracteres");
            RuleFor(x => x.Description)
                .MinimumLength(15)
                    .WithMessage("A Descrição deve ter no mínimo 15 caracteres");
            RuleFor(x => x.Category)
                .MinimumLength(3)
                    .WithMessage("A Categoria deve ter no mínimo 3 caracteres");
            RuleFor(x => x.ExpiresAt)
                .GreaterThan(x => x.CreatedAt)
                    .WithMessage("A Data de Expiração deve ser válida");
            RuleFor(x => x.SalaryOffer)
                .GreaterThan(0)
                    .WithMessage("A Oferta deverá ser maior que 0,00 MT");
        }
    }
}