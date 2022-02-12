using System;
using Supervaga.Domain.Ads;
using Supervaga.Domain.Users;

namespace Tests.Shared.Fixtures
{
    public static class AdFixture
    {
        private static readonly Guid _userId = Guid.NewGuid();
        private static readonly Guid _id = Guid.NewGuid();
        public static readonly Guid Id2 = Guid.NewGuid();

        public static Ad InvalidAd = new Ad(
            "",
            "",
            "",
            "",
            "",
            DateTime.Now.Date,
            new Advantage[] { },
            new Requirement[] { },
            0
        );

        public static Ad ValidAd = new Ad(
            "any title",
            "category",
            "any description",
            "address",
            "audienceGender",
            DateTime.Now.AddMonths(2),
            // new User(
            //     "avatar",
            //     "name",
            //     "password",
            //     "phone",
            //     "address",
            //     "biography",
            //     "email",
            //     "type",
            //     "gender",
            //     "provider",
            //     "cv",
            //     "tag",
            //     "role"
            // ),
            new Advantage[] { new Advantage(_userId, "Seguro de Saúde") },
            new Requirement[] { new Requirement(_userId, "2+ anos .NET") },
            100003
        );

        public static Ad ValidAd2 = new Ad(
            "any title 2",
            "category 2",
            "any description 2",
            "address 2",
            "audienceGender 2",
            DateTime.Now,
            // new User(
            //     "avatar 2",
            //     "name 2",
            //     "password 2",
            //     "phone 2",
            //     "address 2",
            //     "biography 2",
            //     "email 2",
            //     "type 2",
            //     "gender 2",
            //     "provider 2",
            //     "cv 2",
            //     "tag 2",
            //     "role 2"
            // ),
            new Advantage[] { new Advantage(_userId, "Seguro de Saúde 2") },
            new Requirement[] { new Requirement(_userId, "2+ anos .NET 2") },
        200006
        );
    }
}