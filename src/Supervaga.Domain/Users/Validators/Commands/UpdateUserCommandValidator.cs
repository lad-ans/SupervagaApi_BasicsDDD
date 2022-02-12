using System.Text.RegularExpressions;
using FluentValidation;
using Supervaga.Domain.Shared.Consts;
using Supervaga.Domain.Users.Commands;

namespace Supervaga.Domain.Users.Validators.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Id é inválido");
            RuleFor(x => x.Name)
                .MinimumLength(6)
                    .WithMessage("O Nome deve ter no mínimo 6 caracteres");
            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage("O E-mail é inválido");
            RuleFor(x => x.Password)
                .Must(pass => pass == null ? true : Regex.IsMatch(pass ?? "", RegEx.STRONG_PASSWORD))
                    .WithMessage("Escolha uma Senha forte");
        }
    }
}