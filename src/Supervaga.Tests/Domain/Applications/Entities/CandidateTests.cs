using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Applications;

namespace Supervaga.Tests.Domain.Applications
{
    [TestClass]
    public class CandidateTests
    {
        private readonly Candidate _candidate = new Candidate(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "status"
        );

        [TestMethod("Dado um novo Candidate, o mesmo não deve ter CV")]
        public void ValidCandidateGiven()
        {
            Assert.AreEqual(_candidate.IsCv, false);
        }

    }
}