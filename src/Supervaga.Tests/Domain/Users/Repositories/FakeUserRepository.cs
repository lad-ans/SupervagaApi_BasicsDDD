using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Users;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Users.Repositories
{
    public class FakeUserRepository : IRepository<User>
    {
        public async Task Create(User? value)
        {
            await Task.FromResult(0);
        }

        public async Task Delete(User user)
        {
            await Task.FromResult(0);
        }


        public async Task Update(User value)
        {
            await Task.FromResult(0);
        }

        public async Task<User> Get(Guid id)
        {
            return await Task.FromResult(UserFixture.ValidUser);
        }

        public async Task<List<User>> Get(int page, int limit)
        {
            var data = new List<User> { UserFixture.ValidUser };
            return await Task.FromResult(data);
        }

        public Task<List<User>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
    }
}