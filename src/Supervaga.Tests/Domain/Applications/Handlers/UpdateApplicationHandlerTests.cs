using Domain.Applications.Handlers;
using Domain.Shared.Contracts.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Applications;
using Supervaga.Domain.Applications.Commands;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Tests.Domain.Ads.Repositories;
using Supervaga.Tests.Domain.Applications.Repositories;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Applications.Handlers
{
    [TestClass]
    public class UpdateApplicationHandlerTests
    {
        public UpdateApplicationHandlerTests(UpdateApplicationCommand invalidcommand)
        {
            _invalidcommand = new UpdateApplicationCommand(
                ApplicationFixture.InvalidApplication.AdId,
                ApplicationFixture.InvalidApplication.ExpiresAt,
                ApplicationFixture.InvalidApplication.Candidates
            );

            _validcommand = new UpdateApplicationCommand(
                ApplicationFixture.ValidApplication.AdId,
                ApplicationFixture.ValidApplication.ExpiresAt,
                ApplicationFixture.ValidApplication.Candidates
            );

            _invalidcommand.Validate();
            _validcommand.Validate();
        }

        private readonly IHandler<UpdateApplicationCommand> _handler = new UpdateApplicationHandler(
                new FakeApplicationRepository(),
                new FakeAdRepository(),
                new FakeCandidateRepository(),
                new NotificationContext()
            );

        private readonly UpdateApplicationCommand _invalidcommand;
        private readonly UpdateApplicationCommand _validcommand;

        [TestMethod("Dado um commando inválido, deve interomper a execução")]
        public async void InvalidCommandGiven()
        {
            var result = (ValidationErrorsResult)await _handler.Handle(_invalidcommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod("Dado um commando inválido, deve interomper a execução")]
        public async void ValidCommandGiven()
        {
            var result = (OkResult<Application>)await _handler.Handle(_validcommand);
            Assert.AreEqual(result.Success, false);
        }
    }
}

