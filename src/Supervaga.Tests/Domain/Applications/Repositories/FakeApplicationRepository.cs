using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Applications;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Applications.Repositories
{
    public class FakeApplicationRepository : IRepository<Application>
    {
        public async Task Create(Application? value) => await Task.FromResult(0);

        public async Task Delete(Application application) => await Task.FromResult(0);

        public async Task Update(Application value) => await Task.FromResult(0);

        public async Task<Application> Get(Guid id) => await Task.FromResult(
            ApplicationFixture.ValidApplication
        );

        public async Task<List<Application>> Get(int page, int limit)
        {
            var data = new List<Application> { ApplicationFixture.ValidApplication };
            return await Task.FromResult(data);
        }

        public Task<List<Application>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<Application> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
    }
}