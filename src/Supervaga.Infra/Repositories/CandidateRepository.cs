using Domain.Shared.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Supervaga.Domain.Applications;
using Supervaga.Infra.Data.DataContexts;

namespace Infra.Repositories
{
    public class CandidateRepository : IRepository<Candidate>
    {
        public CandidateRepository(DataContext context)
        {
            this.context = context;
        }

        private readonly DataContext context;

        public async Task<List<Candidate>> Get(int page, int limit)
        {
            var cands = await context.Candidates!.AsNoTracking().ToListAsync();
            return cands!;
        }

        public Task<List<Candidate>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Create(Candidate value)
        {
            throw new NotImplementedException();
        }

        public Task Update(Candidate value)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Candidate id)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
    }
}