using System;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Applications;

namespace Tests.Shared.Fixtures
{
    public static class ApplicationFixture
    {
        private static readonly Guid _adId = Guid.NewGuid();
        public static readonly Guid Id2 = Guid.NewGuid();

        public static Application InvalidApplication = new Application(
            _adId,
            DateTime.Now.AddDays(1),
            new Candidate[] {}
        );

        public static Application ValidApplication = new Application(
            _adId,
            DateTime.Now.AddDays(1),
            new Candidate[] {}
        );

        public static Application ValidApplication2 = new Application(
            _adId,
            DateTime.Now.AddDays(3),
            new Candidate[] { CandidateFixture.ValidCandidate }
        );
    }
}