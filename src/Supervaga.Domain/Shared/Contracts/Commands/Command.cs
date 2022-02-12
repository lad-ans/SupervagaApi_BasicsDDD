using FluentValidation;
using FluentValidation.Results;

namespace Supervaga.Domain.Shared.Contracts.Commands
{
    public abstract class Command
    {
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TCommand>(TCommand command, AbstractValidator<TCommand> validator)
        {
            ValidationResult = validator.Validate(command);
            return Valid = ValidationResult.IsValid;
        }
    }
}