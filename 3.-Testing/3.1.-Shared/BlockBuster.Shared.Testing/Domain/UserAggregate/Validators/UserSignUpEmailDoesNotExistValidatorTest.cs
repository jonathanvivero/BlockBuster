using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Domain.UserAggregate;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Validators
{
    [TestFixture]
    public class UserSignUpEmailDoesNotExistValidatorTest
    {
        Mock<IUserRepository> userRepository;
        UserSignUpEmailDoesNotExistValidator validator;
        [SetUp]
        public void Setup()
        {
            userRepository = new Mock<IUserRepository>();
            validator = new UserSignUpEmailDoesNotExistValidator(userRepository.Object);
        }

        [Test]
        public void ValidatorShouldValidateEmailDoesNotExist()
        {
            var userEmail = UserEmailStub.ByDefault().GetValue();
            userRepository.Setup(s => s
                .FindUserByEmail(It.IsAny<UserEmail>()))
                .Returns<UserEmail>(s => null);
            
            void dlg() => validator.Validate(userEmail);

            Assert.DoesNotThrow(dlg);
        }

        [Test]
        public void ValidatorShouldThrowErrorByExistingEmail()
        {
            var user = UserStub.ByDefault();
            var userEmail = UserEmailStub.ByDefault().GetValue();
            userRepository.Setup(s => s
                .FindUserByEmail(It.IsAny<UserEmail>()))
                .Returns(user);

            void dlg() => validator.Validate(userEmail);

            Assert.Throws<UserFoundException>(dlg);
        }
    }
}
