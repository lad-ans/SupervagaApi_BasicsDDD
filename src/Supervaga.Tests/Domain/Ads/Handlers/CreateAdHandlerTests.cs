using System.Threading.Tasks;
using Domain.Ads.Handlers;
using Domain.Shared.Contracts.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Ads.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Tests.Domain.Ads.Repositories;
using Supervaga.Tests.Domain.Applications.Repositories;
using Supervaga.Tests.Domain.Users.Repositories;
using Tests.Shared.Fixtures;

namespace Supervaga.Domain.Ads.Handlers
{
    [TestClass]
    public class CreateAdHandlerTests
    {
        private readonly IHandler<CreateAdCommand> _handler = new CreateAdHandler(
            new FakeAdRepository(),
            new FakeUserRepository(),
            new FakeApplicationRepository(),
            new NotificationContext()
        );

        private readonly CreateAdCommand _validCommand = new CreateAdCommand(
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

        private readonly CreateAdCommand _invalidCommand = new CreateAdCommand(
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

        [TestMethod("Dado um Comando inválido, deve interromper a execução")]
        public async Task InvalidCommandGiven()
        {
            var result = (ValidationErrorsResult)await _handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod("Dado um Comando válido, deve criar uma nova vaga")]
        public async Task ValidCommandGiven()
        {
            var result = (OkResult<Ad>)await _handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}