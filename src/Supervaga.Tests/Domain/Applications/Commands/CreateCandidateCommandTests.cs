using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Candidates.Commands;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Candidates
{
    [TestClass]
    public class CreateCandidateCommandTests
    {

        public CreateCandidateCommandTests()
        {
            _invalidCommand = new CreateCandidateCommand(
                CandidateFixture.InvalidCandidate.ApplicationId,
                CandidateFixture.InvalidCandidate.AdId,
                CandidateFixture.InvalidCandidate.UserId,
                CandidateFixture.InvalidCandidate.Status,
                CandidateFixture.InvalidCandidate.CreatedAt,
                CandidateFixture.InvalidCandidate.IsCv
            );
            _validCommand = new CreateCandidateCommand(
                CandidateFixture.ValidCandidate.ApplicationId,
                CandidateFixture.ValidCandidate.AdId,
                CandidateFixture.ValidCandidate.UserId,
                CandidateFixture.ValidCandidate.Status,
                CandidateFixture.ValidCandidate.CreatedAt,
                CandidateFixture.ValidCandidate.IsCv
            );

            _invalidCommand.Validate(unique: false);
            _validCommand.Validate(unique: true);
        }

        private readonly CreateCandidateCommand _invalidCommand;

        private readonly CreateCandidateCommand _validCommand;


        [TestMethod("Não deve executar o Comando para criação de Candidato dado um Candidato inválido")]
        public void InvalidCandidateGiven()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod("Deve executar o Comando para criação de Candidato dado um Candidato válido")]
        public void ValidCandidateGiven()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }

    }
}