using FluentValidation;
using Supervaga.Domain.Users.Commands;

namespace Supervaga.Domain.Users.Validators.Commands
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Id é inválido");
        }
    }
}