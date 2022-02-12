using Supervaga.Domain.Auth.Validators.Commands;
using Supervaga.Domain.Shared.Contracts.Commands;

namespace Supervaga.Domain.Auth.Commands
{
    public class LoginCommand : Command
    {
        public LoginCommand()
        {
        }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public void Validate() => Validate(this, new LoginCommandValidator());
    }
}

