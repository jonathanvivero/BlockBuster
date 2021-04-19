using NUnit.Framework;
using Moq;
using BlockBuster.IAM.Infrastructure.Factory;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using System;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.Shared.Domain.Exceptions;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Factory
{
    [TestFixture]
    public class UserFactoryTest
    {
        Mock<IHashing> hashingService = new Mock<IHashing>();
        UserFactory userFactory;

        [SetUp]
        public void Setup()
        {
            userFactory = new UserFactory(hashingService.Object);
            var defaultHashedPassword = UserHashedPasswordStub.ByDefault();
            hashingService.Setup(s => s.Hash(It.IsAny<string>()))
                .Returns(defaultHashedPassword);
        }

        [Test]
        public void UserFactoryShouldCreateAValidSignedUpUser ()
        {
            var userEmail = UserEmailStub.ByDefault();
            var userId = UserIdStub.ByDefault();
            var now = DateTime.Now; 

            var user = userFactory.Create(
                userId.GetValue(),
                userEmail.GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.ByDefault().GetValue(),
                UserCountryIdStub.ByDefault().GetValue()
                );

            Assert.AreEqual(user.Email.GetValue(), userEmail.GetValue());
            Assert.AreEqual(user.Id.GetValue(), userId.GetValue());
            Assert.IsTrue(now <= user.CreatedAt.GetValue());
        }

        [Test]
        public void UserFactoryShouldThrowErrorForBadPassword()
        {
            var userEmail = UserEmailStub.ByDefault();
            var userId = UserIdStub.ByDefault();

            void dlg() => userFactory.Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.WrongPattern().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.ByDefault().GetValue(),
                UserCountryIdStub.ByDefault().GetValue()
                );

            Assert.Throws<InvalidAttributeException>(dlg);
        }

        [Test]
        public void UserFactoryShouldThrowErrorPasswordsDontMatch()
        {
            var userEmail = UserEmailStub.ByDefault();
            var userId = UserIdStub.ByDefault();

            void dlg() => userFactory.Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.DifferentToDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.ByDefault().GetValue(),
                UserCountryIdStub.ByDefault().GetValue()
                );

            Assert.Throws<InvalidUserAttributeException>(dlg);
        }

        [Test]
        public void UserFactoryShouldThrowErrorRoleNotValid()
        {
            var userEmail = UserEmailStub.ByDefault();
            var userId = UserIdStub.ByDefault();

            void dlg() => userFactory.Create(
                UserIdStub.ByDefault().GetValue(),
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.NotExistingRole().GetValue(),
                UserCountryIdStub.ByDefault().GetValue()
                );

            var ex = Assert.Throws(typeof(InvalidAttributeException),dlg);
            Assert.IsTrue(ex.Message.Contains("Role"));         
        }


    }
}
