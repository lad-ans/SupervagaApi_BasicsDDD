using System.Collections.Generic;
using System.Linq;
using Domain.Ads.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Ads;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Queries
{
    [TestClass]
    public class AdQueriesTests
    {
        public AdQueriesTests()
        {
            AdFixture.ValidAd2.Id = AdFixture.Id2;
        }

        readonly private IList<Ad> _ads = new List<Ad> {
            AdFixture.ValidAd, AdFixture.ValidAd2
        };

        [TestMethod("Deve retornar todas as vagas")]
        public void QueryGiven()
        {
            var result = _ads.AsQueryable().Where(AdQueries.Get());
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod("Deve retornar vaga correspondendo ao ID informado")]
        public void QueryGivenById()
        {
            var result = _ads.AsQueryable().Where(AdQueries.Get(AdFixture.Id2));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod("Deve retornar vaga correspondendo a chave de pesquisa informada")]
        public void QueryGivenByResearch()
        {
            var result = _ads.AsQueryable().Where(AdQueries.GetResearched("any description 2"));
            Assert.AreEqual(1, result.Count());
        }
    }
}