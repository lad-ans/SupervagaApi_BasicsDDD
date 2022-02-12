using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Ads;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Ads.Repositories
{
    public class FakeAdRepository : IRepository<Ad>
    {
        public async Task Create(Ad? value)
        {
            await Task.FromResult(0);
        }

        public async Task Delete(Ad ad)
        {
            await Task.FromResult(0);
        }


        public async Task Update(Ad value)
        {
            await Task.FromResult(0);
        }

        public async Task<Ad> Get(Guid id)
        {
            return await Task.FromResult(
                AdFixture.ValidAd
            );
        }

        public async Task<List<Ad>> Get(int page, int limit)
        {
            var data = new List<Ad> { AdFixture.ValidAd };
            return await Task.FromResult(data);
        }

        public Task<List<Ad>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<Ad> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
    }
}