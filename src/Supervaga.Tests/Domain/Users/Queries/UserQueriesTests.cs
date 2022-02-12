using System.Collections.Generic;
using System.Linq;
using Domain.Users.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supervaga.Domain.Users;
using Tests.Shared.Fixtures;

namespace Supervaga.Tests.Domain.Queries
{
    [TestClass]
    public class UserQueriesTests
    {
        public UserQueriesTests()
        {
            UserFixture.ValidUser2.Id = UserFixture.Id2;
        }

        readonly private IList<User> _ads = new List<User> {
            UserFixture.ValidUser, UserFixture.ValidUser2
        };

        [TestMethod("Deve retornar todos os usuários")]
        public void QueryGiven()
        {
            var result = _ads.AsQueryable().Where(UserQueries.Get());
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod("Deve retornar usuário correspondendo ao ID informado")]
        public void QueryGivenById()
        {
            var result = _ads.AsQueryable().Where(UserQueries.Get(UserFixture.Id2));
            Assert.AreEqual(1, result.Count());
        }

    }
}