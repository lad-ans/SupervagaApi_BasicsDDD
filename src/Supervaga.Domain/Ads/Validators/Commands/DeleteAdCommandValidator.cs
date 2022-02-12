using FluentValidation;
using Supervaga.Domain.Ads.Commands;

namespace Supervaga.Domain.Ads.Validators.Commands
{
    public class DeleteAdCommandValidator : AbstractValidator<DeleteAdCommand>
    {
        public DeleteAdCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Usuário é inválido"); ;
        }
    }
}