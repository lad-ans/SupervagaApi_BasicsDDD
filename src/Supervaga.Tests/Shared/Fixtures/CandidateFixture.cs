using System;
using Supervaga.Domain.Applications;

namespace Tests.Shared.Fixtures
{
    public static class CandidateFixture
    {
        private static readonly Guid _adId = Guid.NewGuid();
        private static readonly Guid _applicationId = Guid.NewGuid();
        private static readonly Guid _userId = Guid.NewGuid();

        public static Candidate ValidCandidate = new Candidate(
            _applicationId,
            _adId,
            _userId,
            "status"
        );

        public static Candidate InvalidCandidate = new Candidate(
            _applicationId,
            _adId,
            _userId,
            ""
        );
    }
}