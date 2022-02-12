using System.Text.RegularExpressions;
using FluentValidation;
using Supervaga.Domain.Auth.Commands;
using Supervaga.Domain.Shared.Consts;

namespace Supervaga.Domain.Auth.Validators.Commands
{
    public class SocialAuthCommandValidator : AbstractValidator<SocialAuthCommand>
    {
        public SocialAuthCommandValidator()
        {
            RuleFor(x => x.token)
                .NotNull()
                    .WithMessage("O TokenId é obrigatório")
                .Must(idToken => Regex.IsMatch(idToken ?? "", RegEx.JWT))
                    .WithMessage("TokenId inválido");
        }
    }
}