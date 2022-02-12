using FluentValidation;
using Supervaga.Domain.DocumentCommands;

namespace Supervaga.Domain.Documents
{
    public class DocumentValidator : AbstractValidator<DocumentCommand>
    {
        public DocumentValidator()
        {
            RuleFor(x => x.docs)
                .NotNull()
                    .WithMessage("O Ficheiro é obrigatório")
                .NotEmpty()
                    .WithMessage("Ficheiro(s) inválido(s)");
        }
    }
}