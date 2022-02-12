using System.Text.RegularExpressions;
using FluentValidation;
using Supervaga.Domain.Shared.Consts;
using Supervaga.Domain.Users.Commands;

namespace Supervaga.Domain.Users.Validators.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                    .WithMessage("O Nome é obrigatório")
                .MinimumLength(6)
                    .WithMessage("O Nome deve ter no mínimo 6 caracteres");
            RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage("O E-mail é inválido");
            RuleFor(x => x.Password)
                .NotNull()
                    .WithMessage("A Senha é obrigatória")
                .Must(pass => Regex.IsMatch(pass ?? "", RegEx.STRONG_PASSWORD))
                    .WithMessage("Escolha uma Senha forte");
        }
    }
}