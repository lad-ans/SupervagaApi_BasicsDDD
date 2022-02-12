using Domain.Ads.Queries;
using Domain.Shared.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Users;
using Supervaga.Infra.Data.DataContexts;

namespace Infra.Repositories
{
    public class AdRepository : IRepository<Ad>
    {
        public AdRepository(DataContext context)
        {
            this.context = context;
        }

        private readonly DataContext context;
        public async Task<List<Ad>> Get(int page, int limit)
        {
            var ads = new List<Ad?>();
            foreach (var ad in context.Ads!.ToList())
                ads.Add(
                    await context.Ads!
                        .AsNoTracking()
                        .Include(x => x.User)
                        .Include(x => x.Advantages)
                        .Include(x => x.Requirements)
                        .Skip(page * limit)
                        .Take(limit)
                        .FirstOrDefaultAsync(AdQueries.Get(ad.Id))
                );

            return ads!;
        }

        public async Task<Ad> Get(Guid id)
        {
            var ad = await context.Ads!
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x!.Advantages!.AsQueryable().Where(AdQueries.GetAdvantageByAdId(id)))
                .Include(x => x!.Requirements!.AsQueryable().Where(AdQueries.GetRequirementByAdId(id)))
                .FirstOrDefaultAsync(AdQueries.Get(id));

            return ad!;
        }

        public async Task<List<Ad>> Search(string key, int page, int limit)
        {
            var ads = new List<Ad?>();
            var _ads = context.Ads!.AsNoTracking().Where(AdQueries.GetResearched(key)).ToList();
            if (ads != null && _ads.Count() > 0)
            {
                foreach (var ad in _ads)
                    ads.Add(
                        await context.Ads!
                            .AsNoTracking()
                            .Include(x => x.User)
                            .Include(x => x.Advantages!.AsQueryable().Where(AdQueries.GetAdvantageByAdId(ad.Id)))
                            .Include(x => x.Requirements!.AsQueryable().Where(AdQueries.GetRequirementByAdId(ad.Id)))
                            .Skip(page * limit)
                            .Take(limit)
                            .FirstOrDefaultAsync(AdQueries.Get(ad.Id))
                    );
            }

            return ads!;
        }

        public async Task Create(Ad value)
        {
            context?.Ads?.Add(value);
            await context!.SaveChangesAsync();
        }

        public async Task Delete(Ad value)
        {
            context.Ads!.Remove(value);
            await context.SaveChangesAsync();
        }

        public async Task Update(Ad value)
        {
            context.Entry<Ad>(value).State = EntityState.Detached;
            context.Entry<Ad>(value).State = EntityState.Modified;
            _removeRequirementAndAdvantage(value.Id);
            _addRequirementAndAdvantage(value);
            await context.SaveChangesAsync();
        }

        #region Helpers Methods
        private void _addRequirementAndAdvantage(Ad value)
        {
            value!.Requirements!.ToList().ForEach(r => context?.Requirements!.Add(r));
            value!.Advantages!.ToList().ForEach(a => context?.Advantages!.Add(a));
        }

        private void _removeRequirementAndAdvantage(Guid id)
        {
            var advs = context.Advantages!.AsNoTracking().Where(AdQueries.GetAdvantageByAdId(id)).ToList();
            var reqs = context.Requirements!.AsNoTracking().Where(AdQueries.GetRequirementByAdId(id)).ToList();

            advs.ForEach(x => context.Remove(x));
            context.SaveChanges();

            reqs.ForEach(x => context.Remove(x));
            context.SaveChanges();
        }

        public Task<Ad> Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}