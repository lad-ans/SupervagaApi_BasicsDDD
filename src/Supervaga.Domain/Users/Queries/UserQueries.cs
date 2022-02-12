using System.Linq.Expressions;
using Supervaga.Domain.Users;

namespace Domain.Users.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> Get()
        {
            return x => true;
        }

        public static Expression<Func<User, bool>> Get(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<User, bool>> Get(string email, string password)
        {
            return x => x.Email == email && x.Password == password;
        }

    }
}