using Supervaga.Domain.Ads.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.Ads.Commands
{
    public class DeleteAdCommand : Command
    {
        public DeleteAdCommand()
        {
        }

        public DeleteAdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public void Validate() => Validate(this, new DeleteAdCommandValidator());
    }

}