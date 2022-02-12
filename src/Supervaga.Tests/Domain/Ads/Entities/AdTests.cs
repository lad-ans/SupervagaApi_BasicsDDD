using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Ads;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Ads
{
    [TestClass]
    public class UnitTests
    {
        private readonly Ad _ad = AdFixture.ValidAd;

        [TestMethod("Dado um novo Ad, o mesmo não deve ser Freelance")]
        public void ValidAdGiven()
        {
            Assert.AreEqual(_ad.IsFreelance, false);
        }
    }
}

