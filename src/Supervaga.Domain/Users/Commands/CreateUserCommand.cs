using Supervaga.Domain.Shared.Contracts.Commands;
using Supervaga.Domain.Users.Validators.Commands;

namespace Supervaga.Domain.Users.Commands
{
    public class CreateUserCommand : Command
    {
        public CreateUserCommand()
        {
        }

        public CreateUserCommand(
            string avatar,
            string name,
            string password,
            string phone,
            string address,
            string biography,
            string email,
            string type,
            string gender,
            string provider,
            string cv,
            string tag,
            string role
        )
        {
            Avatar = avatar;
            Name = name;
            Password = password;
            Phone = phone;
            Address = address;
            Biography = biography;
            Email = email;
            Type = type;
            Gender = gender;
            Provider = provider;
            Cv = cv;
            Tag = tag;
            Role = role;
        }

        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Biography { get; set; }
        public string? Email { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? Provider { get; set; }
        public string? Cv { get; set; }
        public string? Tag { get; set; }
        public string? Role { get; set; }
        public void Validate() => Validate(this, new CreateUserCommandValidator());
    }


}