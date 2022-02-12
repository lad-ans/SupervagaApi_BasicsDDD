using Supervaga.Domain.Shared.Contracts.Entities;

namespace Supervaga.Domain.Users
{
    public class User : Entity
    {
        public User()
        {
        }
        public User(
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
            Avatar = avatar!;
            Name = name!;
            Password = password!;
            Phone = phone!;
            Address = address!;
            Biography = biography!;
            Email = email!;
            Type = type!;
            Gender = gender!;
            Provider = provider!;
            Cv = cv!;
            Tag = tag!;
            Role = role ?? "common";
        }

        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; private set; }
        public string? Address { get; private set; }
        public string? Biography { get; private set; }
        public string? Email { get; set; }
        public string? Type { get; private set; }
        public string? Gender { get; private set; }
        public string? Provider { get; set; }
        public string? Cv { get; private set; }
        public string? Tag { get; private set; }
        public string? Role { get; set; }

        public User Copy(User value)
        {
            User newValue = value;

            newValue.Id = value.Id;
            newValue.Avatar = value.Avatar; 
            newValue.Name = value.Name;
            newValue.Password = value.Password;
            newValue.Phone = value.Phone;
            newValue.Biography = value.Biography;
            newValue.Email = value.Email;
            newValue.Type = value.Type;
            newValue.Gender = value.Gender;
            newValue.Provider = value.Provider;
            newValue.Cv = value.Cv;
            newValue.Tag = value.Tag;
            newValue.Role = value.Role;

            return newValue;
        }
    }
}