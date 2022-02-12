using Supervaga.Domain.Users;

namespace Supervaga.Domain.Auth.Entities
{
    public class Login
    {
        public Login()
        {
        }

        public Login(User user, string token)
        {
            User = user;
            Token = token;
        }

        public User? User { get; set; }
        public string? Token { get; set; }
    }
}