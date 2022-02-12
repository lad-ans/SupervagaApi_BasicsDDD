using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Shared.Contracts.Repositories;
using Supervaga.Domain.Applications;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Applications.Repositories
{
    public class FakeCandidateRepository : IRepository<Candidate>
    {
        public async Task Create(Candidate? value) => await Task.FromResult(0);

        public async Task Delete(Candidate application) => await Task.FromResult(0);

        public async Task Update(Candidate value) => await Task.FromResult(0);

        public async Task<Candidate> Get(Guid id) => await Task.FromResult(
            CandidateFixture.ValidCandidate
        );

        public async Task<List<Candidate>> Get(int page, int limit)
        {
            var data = new List<Candidate> { CandidateFixture.ValidCandidate };
            return await Task.FromResult(data);
        }

        public Task<List<Candidate>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
    }
}