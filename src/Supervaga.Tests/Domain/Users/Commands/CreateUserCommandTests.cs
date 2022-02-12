using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Users.Commands;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Users.Commands
{
    [TestClass]
    public class CreateUserCommandTests
    {
        public CreateUserCommandTests()
        {
            _invalidCommand = new CreateUserCommand(
                UserFixture.InvalidUser!.Avatar!,
                UserFixture.InvalidUser?.Name!,
                UserFixture.InvalidUser?.Password!,
                UserFixture.InvalidUser?.Phone!,
                UserFixture.InvalidUser?.Address!,
                UserFixture.InvalidUser?.Biography!,
                UserFixture.InvalidUser?.Email!,
                UserFixture.InvalidUser?.Type!,
                UserFixture.InvalidUser?.Gender!,
                UserFixture.InvalidUser?.Provider!,
                UserFixture.InvalidUser?.Cv!,
                UserFixture.InvalidUser?.Tag!,
                UserFixture.InvalidUser?.Role!
            );

            _validCommand = new CreateUserCommand(
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

            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        private readonly CreateUserCommand _invalidCommand;
        private readonly CreateUserCommand _validCommand;

        [TestMethod("Não deve criar Usuário ao passar um Comando inválido")]
        public void InvalidCommandGiven()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod("Deve criar Usuário ao passar um Comando válido")]
        public void ValidCommandGiven()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}