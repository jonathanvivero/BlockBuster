using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void UserCreateShouldCreatedUserSuccessfully()
        {
            var user = User.SignUp(
                UserIdStub.ByDefault(),
                UserEmailStub.ByDefault(),
                UserHashedPasswordStub.ByDefault(),
                UserFirstNameStub.ByDefault(),
                UserLastNameStub.ByDefault(),
                UserRoleStub.ByDefault(),
                UserCountryIdStub.ByDefault()
                );

            Assert.AreEqual(user.Id, UserIdStub.ByDefault());
            Assert.AreEqual(user.Email, UserEmailStub.ByDefault());
            Assert.AreEqual(user.CountryId, UserCountryIdStub.ByDefault());
            Assert.AreEqual(user.FirstName, UserFirstNameStub.ByDefault());
            Assert.AreEqual(user.LastName, UserLastNameStub.ByDefault());
            Assert.AreEqual(user.Role, UserRoleStub.ByDefault());
            Assert.AreEqual(user.HashedPassword, UserHashedPasswordStub.ByDefault());

        }
    }        
}
