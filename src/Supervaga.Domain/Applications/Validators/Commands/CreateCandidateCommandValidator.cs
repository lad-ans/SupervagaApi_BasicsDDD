using System.Text.RegularExpressions;
using FluentValidation;
using Supervaga.Domain.Candidates.Commands;
using Supervaga.Domain.Shared.Consts;

namespace Supervaga.Domain.Applications.Validators.Commands
{
    public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        public CreateCandidateCommandValidator(bool unique)
        {
            RuleFor(x => x)
                .Must(x => x.ApplicationId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Id da Candidtura é inválido");
            RuleFor(x => x)
                .Must(x => x.AdId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Id da Vaga é inválido");
            RuleFor(x => x)
                .Must(x => x.UserId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Usuário é inválido")
                .Must(x => {var s = x.UserId.ToString(); return Regex.IsMatch(s, RegEx.GUID.ToLower());}) // x.UserId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    .WithMessage("O Usuário não é um GUID/UUID válido")
                .Must(x => unique)
                    .WithMessage("Candidato existe");
            RuleFor(x => x.Status)
                .NotNull()
                    .WithMessage("O Status é obrigatório")
                .NotEmpty()
                    .WithMessage("o Status do Candidato é inválido");
        }
    }
}