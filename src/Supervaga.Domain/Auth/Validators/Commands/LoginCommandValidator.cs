using System.Text.RegularExpressions;
using FluentValidation;
using Supervaga.Domain.Auth.Commands;
using Supervaga.Domain.Shared.Consts;

namespace Supervaga.Domain.Auth.Validators.Commands
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                    .WithMessage("O Email é obrigatório")
                .EmailAddress()
                    .WithMessage("O E-mail é inválido");
            RuleFor(x => x.Password)
                .NotNull()
                    .WithMessage("A Senha é obrigatória")
                .Must(pass => Regex.IsMatch(pass ?? "", RegEx.STRONG_PASSWORD))
                    .WithMessage("Senha inválida");
        }
    }
}