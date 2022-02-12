using System.Collections.Generic;
using System.Linq;
using Domain.Applications.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Applications;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Queries
{
    [TestClass]
    public class ApplicationQueriesTests
    {
        public ApplicationQueriesTests()
        {
            ApplicationFixture.ValidApplication2.Id = ApplicationFixture.Id2;
        }

        readonly private IList<Application> _ads = new List<Application> {
            ApplicationFixture.ValidApplication, ApplicationFixture.ValidApplication2
        };

        [TestMethod("Deve retornar todas as candidaturas")]
        public void QueryGiven()
        {
            var result = _ads.AsQueryable().Where(ApplicationQueries.Get());
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod("Deve retornar candidatura correspondendo ao ID informado")]
        public void QueryGivenById()
        {
            var result = _ads.AsQueryable().Where(ApplicationQueries.Get(ApplicationFixture.Id2));
            Assert.AreEqual(1, result.Count());
        }

    }
}