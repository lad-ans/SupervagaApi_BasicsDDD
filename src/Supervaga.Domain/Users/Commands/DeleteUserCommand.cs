using Supervaga.Domain.Shared.Contracts.Commands;
using Supervaga.Domain.Users.Validators.Commands;

namespace Supervaga.Domain.Users.Commands
{
    public class DeleteUserCommand : Command
    {
        public DeleteUserCommand()
        {
        }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public void Validate() => Validate(this, new DeleteUserCommandValidator());
    }

}