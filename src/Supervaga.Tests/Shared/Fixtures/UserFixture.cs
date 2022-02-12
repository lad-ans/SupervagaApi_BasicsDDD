using System;
using Supervaga.Domain.Users;

namespace Tests.Shared.Fixtures
{
    public static class UserFixture
    {
        public static readonly Guid Id2 = Guid.NewGuid();

        public static User ValidUser = new User(
            "avatar",
            "any name",
            "!Camisa10!",
            "phone",
            "address",
            "biography",
            "email@email.com",
            "type",
            "gender",
            "provider",
            "cv",
            "tag",
            "role"
        );

        public static User ValidUser2 = new User(
            "avatar 2",
            "any name 2",
            "!Camisa10!",
            "phone 2",
            "address 2",
            "biography 2",
            "email2@email.com",
            "type 2",
            "gender 2",
            "provider 2",
            "cv 2",
            "tag 2",
            "role 2"
        );


        public static User InvalidUser = new User(
            "", "", "", "", "", "", "", "", "", "", "", "", ""
        );
    }
}