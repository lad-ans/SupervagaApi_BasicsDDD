using Domain.Applications.Queries;
using Domain.Shared.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Supervaga.Domain.Applications;
using Supervaga.Infra.Data.DataContexts;
using _apps = Supervaga.Domain.Applications;

namespace Infra.Repositories
{
    public class ApplicationRepository : IRepository<_apps.Application>
    {
        public ApplicationRepository(DataContext context)
        {
            this.context = context;
        }

        private readonly DataContext context;

        public async Task<List<_apps.Application>> Get(int page, int limit)
        {
            var apps = new List<_apps.Application?>();
            foreach (var app in context.Applications!.ToList())
                apps.Add(
                    await context.Applications!
                        .AsNoTracking()
                        .Include(x => x.Ad)
                        .Include(x => x.Ad!.User)
                        .Include(x => x.Ad!.Advantages!.AsQueryable().Where(ApplicationQueries.GetAdvanByAdId(app.AdId)))
                        .Include(x => x.Ad!.Requirements!.AsQueryable().Where(ApplicationQueries.GetReqByAdId(app.AdId)))
                        .Include(x => x.Candidates!.AsQueryable().Where(ApplicationQueries.GetCandidateByApplicationId(app.Id)))
                        .FirstOrDefaultAsync(ApplicationQueries.Get(app.Id))
                );

            return apps!;
        }

        public async Task<_apps.Application> Get(Guid id)
        {
            var _app = await context.Applications!.AsNoTracking().FirstOrDefaultAsync(ApplicationQueries.Get(id));
            var app = new Application();
            if (_app != null)
                app = await context.Applications!
                    .AsNoTracking()
                    .Include(x => x.Ad)
                    .Include(x => x!.Ad!.User)
                    .Include(x => x.Ad!.Advantages!.AsQueryable().Where(ApplicationQueries.GetAdvanByAdId(_app!.AdId)))
                    .Include(x => x.Ad!.Requirements!.AsQueryable().Where(ApplicationQueries.GetReqByAdId(_app!.AdId)))
                    .Include(x => x.Candidates!.AsQueryable().Where(ApplicationQueries.GetCandidateByApplicationId(id)))
                    .FirstOrDefaultAsync(ApplicationQueries.Get(id));
            return app!;
        }

        public async Task Create(_apps.Application value)
        {
            context.Applications!.Add(value);
            await context.SaveChangesAsync();
        }

        public async Task Update(_apps.Application value)
        {
            context.Entry<_apps.Application>(value).State = EntityState.Detached;
            context.Entry<_apps.Application>(value).State = EntityState.Modified;
            _removeCandidate(value.Id);
            _addCandidate(value);
            await context.SaveChangesAsync();
        }

        public Task Delete(_apps.Application application)
        {
            throw new NotImplementedException();
        }

        public Task<List<_apps.Application>> Search(string key, int page, int limit)
        {
            throw new NotImplementedException();
        }

        #region Helpers Methods
        private void _addCandidate(Application value) => value!.Candidates!.ToList().ForEach(cand => context?.Candidates?.Add(cand));

        private void _removeCandidate(Guid id)
        {
            var candidates = context.Candidates!.AsNoTracking().Where(
                ApplicationQueries.GetCandidateByApplicationId(id) 
            ).ToList();

            candidates.ForEach(x => context.Candidates!.Remove(x));
            context.SaveChanges();
        }

        public Task<Application> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}