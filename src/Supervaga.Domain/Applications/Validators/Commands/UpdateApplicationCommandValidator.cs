using FluentValidation;
using Supervaga.Domain.Applications.Commands;

namespace Supervaga.Domain.Applications.Validators.Commands
{
    public class UpdateApplicationCommandValidator : AbstractValidator<UpdateApplicationCommand>
    {
        public UpdateApplicationCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Id da Candidatura é inválido");
            RuleFor(x => x)
                .Must(x => x.AdId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("A Vaga é inválida");
            RuleFor(x => x.ExpiresAt)
                .GreaterThan(x => x.CreatedAt)
                    .WithMessage("A Data de Expiração deve ser válida");
        }
    }
}