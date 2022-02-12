using System.Linq.Expressions;
using Supervaga.Domain.Ads;

namespace Domain.Ads.Queries
{
    public static class AdQueries
    {
        public static Expression<Func<Ad, bool>> Get()
        {
            return x => true;
        }

        public static Expression<Func<Ad, bool>> Get(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Advantage, bool>> GetAdvantageByAdId(Guid id)
        {
            return x => x.AdId == id;
        }

        public static Expression<Func<Requirement, bool>> GetRequirementByAdId(Guid id)
        {
            return x => x.AdId == id;
        }

        public static Expression<Func<Ad, bool>> GetResearched(string key)
        {
            return x => x.Category!.ToLower().Contains(key.ToLower())
                || x.Title!.ToLower().Contains(key.ToLower())
                || x.Description!.ToLower().Contains(key.ToLower())
                || x.Address!.ToLower().Contains(key.ToLower());
        }

    }
}