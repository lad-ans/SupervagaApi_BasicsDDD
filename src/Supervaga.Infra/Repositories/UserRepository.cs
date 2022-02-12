using Domain.Shared.Contracts.Repositories;
using Domain.Users.Queries;
using Microsoft.EntityFrameworkCore;
using Supervaga.Domain.Users;
using Supervaga.Infra.Data.DataContexts;

namespace Infra.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        private readonly DataContext context;

        public async Task<List<User>> Get(int page, int limit)
        {
            var users = await context.Users!
                .AsNoTracking()
                .Skip(page * limit)
                .Take(limit)
                .ToListAsync();

            return users;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await context.Users!
                .AsNoTracking()
                .FirstOrDefaultAsync(UserQueries.Get(id));

            return user!;
        }

        public async Task<User> Get(string email, string password)
        {
            var user = await context.Users!
                .AsNoTracking()
                .FirstOrDefaultAsync(UserQueries.Get(email, password));
                
            return user!;
        }

        public async Task Create(User value)
        {
            context.Users!.Add(value);
            await context.SaveChangesAsync();
        }

        public async Task Update(User value)
        {
            context.Entry<User>(value).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            context.Users!.Remove(user);
            await context.SaveChangesAsync();
        }

        public Task<List<User>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

    }
}