using Supervaga.Domain.Shared.Contracts.Commands;
using Supervaga.Domain.Users.Validators.Commands;

namespace Supervaga.Domain.Users.Commands
{
    public class UpdateUserCommand : Command
    {
        public UpdateUserCommand()
        {
        }

        public UpdateUserCommand(
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

        public Guid Id { get; set; }
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

        public UpdateUserCommand CopyWith(Guid id, User user)
        {
            UpdateUserCommand command = new UpdateUserCommand();
            command.Id = id;

            command.Avatar = this.Avatar ?? user.Avatar;
            command.Name = this.Name ?? user.Name;
            command.Password = this.Password ?? user.Password;
            command.Phone = this.Phone ?? user.Phone;
            command.Address = this.Address ?? user.Address;
            command.Biography = this.Biography ?? user.Biography;
            command.Email = this.Email ?? user.Email;
            command.Type = this.Type ?? user.Type;
            command.Gender = this.Gender ?? user.Gender;
            command.Provider = this.Provider ?? user.Provider;
            command.Cv = this.Cv ?? user.Cv;
            command.Tag = this.Tag ?? user.Tag;
            command.Role = this.Role ?? user.Role;

            return command;
        }

        public void Validate() => Validate(this, new UpdateUserCommandValidator());
    }

}