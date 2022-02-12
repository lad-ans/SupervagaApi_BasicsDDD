using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Ads.Commands;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Ads.Commands
{
    [TestClass]
    public class CreateAdCommandTests
    {
        public CreateAdCommandTests()
        {
            _invalidCommand = new CreateAdCommand(
                UserFixture.Id2,
                AdFixture.InvalidAd.Title,
                AdFixture.InvalidAd.Category,
                AdFixture.InvalidAd.Description,
                AdFixture.InvalidAd.Address,
                AdFixture.InvalidAd.AudienceGender,
                AdFixture.InvalidAd.CreatedAt,
                AdFixture.InvalidAd.ExpiresAt,
                AdFixture.InvalidAd.IsFreelance,
                AdFixture.InvalidAd.Advantages,
                AdFixture.InvalidAd.Requirements,
                salaryOffer: AdFixture.InvalidAd.SalaryOffer
            );
            _validCommand = new CreateAdCommand(
                UserFixture.Id2,
                AdFixture.ValidAd.Title,
                AdFixture.ValidAd.Category,
                AdFixture.ValidAd.Description,
                AdFixture.ValidAd.Address,
                AdFixture.ValidAd.AudienceGender,
                AdFixture.ValidAd.CreatedAt,
                AdFixture.ValidAd.ExpiresAt,
                AdFixture.ValidAd.IsFreelance,
                AdFixture.ValidAd.Advantages,
                AdFixture.ValidAd.Requirements,
                salaryOffer: AdFixture.ValidAd.SalaryOffer
            );

            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        private readonly CreateAdCommand _invalidCommand;
        private readonly CreateAdCommand _validCommand;

        [TestMethod("Não deve criar Ad ao passar um Comando inválido")]
        public void InvalidCommandGiven()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod("Deve criar Ad ao passar um Comando válido")]
        public void ValidCommandGiven()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}