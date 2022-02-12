using System.Threading.Tasks;
using Domain.Shared.Contracts.Handlers;
using Domain.Users.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Auth.Entities;
using Supervaga.Domain.Auth.Handlers;
using Supervaga.Domain.Results;
using Supervaga.Domain.Shared.Contracts.Results;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Domain.Users.Commands;
using Supervaga.Tests.Domain.Users.Repositories;
using Tests.Shared.Fixtures;

namespace Supervaga.Domain.Users.Handlers
{
    [TestClass]
    public class CreateUserHandlerTests
    {
        private readonly IHandler<CreateUserCommand> _handler = new CreateUserHandler(
            new FakeUserRepository(),
            new LoginHandler(
                new FakeUserRepository(),
                new NotificationContext()
            ),
            new NotificationContext()
        );
        private readonly CreateUserCommand _validCommand = new CreateUserCommand(
            UserFixture.ValidUser!.Avatar!,
            UserFixture.ValidUser!.Name!,
            UserFixture.ValidUser!.Password!,
            UserFixture.ValidUser!.Phone!,
            UserFixture.ValidUser!.Address!,
            UserFixture.ValidUser!.Biography!,
            UserFixture.ValidUser!.Email!,
            UserFixture.ValidUser!.Type!,
            UserFixture.ValidUser!.Gender!,
            UserFixture.ValidUser!.Provider!,
            UserFixture.ValidUser!.Cv!,
            UserFixture.ValidUser!.Tag!,
            UserFixture.ValidUser!.Role!
        );

        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand(
            UserFixture.InvalidUser!.Avatar!,
            UserFixture.InvalidUser!.Name!,
            UserFixture.InvalidUser!.Password!,
            UserFixture.InvalidUser!.Phone!,
            UserFixture.InvalidUser!.Address!,
            UserFixture.InvalidUser!.Biography!,
            UserFixture.InvalidUser!.Email!,
            UserFixture.InvalidUser!.Type!,
            UserFixture.InvalidUser!.Gender!,
            UserFixture.InvalidUser!.Provider!,
            UserFixture.InvalidUser!.Cv!,
            UserFixture.InvalidUser!.Tag!,
            UserFixture.InvalidUser!.Role!
        );

        [TestMethod("Dado um Comando inválido, deve interromper a execução")]
        public async Task InvalidCommandGiven()
        {
            var result = (ValidationErrorsResult)await _handler.Handle(_invalidCommand);
            Assert.AreEqual(result?.Success, false);
        }

        [TestMethod("Dado um Comando válido, deve criar um novo Usuário e recuperar o token")]
        public async Task ValidCommandGiven()
        {
            var result = (OkResult<Login>)await _handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}