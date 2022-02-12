using Supervaga.Domain.Auth.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.Auth.Commands
{
    public class SocialAuthCommand : Command
    {
        public SocialAuthCommand()
        {
        }

        public SocialAuthCommand(string idToken)
        {
            token = idToken;
        }

        public string? token { get; set; }

        public void Validate() => Validate(this, new SocialAuthCommandValidator());
    }
}

