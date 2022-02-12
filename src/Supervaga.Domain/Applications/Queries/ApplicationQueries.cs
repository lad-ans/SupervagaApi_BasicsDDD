using System.Linq.Expressions;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Applications;

namespace Domain.Applications.Queries
{
    public static class ApplicationQueries
    {
        public static Expression<Func<Application, bool>> Get()
        {
            return x => true;
        }

        public static Expression<Func<Application, bool>> Get(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Advantage, bool>> GetAdvanByAdId(Guid id)
        {
            return x => x.AdId == id;
        }

        public static Expression<Func<Requirement, bool>> GetReqByAdId(Guid id)
        {
            return x => x.AdId == id;
        }

        public static Expression<Func<Candidate, bool>> GetCandidateByApplicationId(Guid id)
        {
            return x => x.ApplicationId == id;
        }

        public static Expression<Func<Candidate, bool>> GetCandidateByUserId(Guid id)
        {
            return x => x.UserId == id;
        }

    }
}