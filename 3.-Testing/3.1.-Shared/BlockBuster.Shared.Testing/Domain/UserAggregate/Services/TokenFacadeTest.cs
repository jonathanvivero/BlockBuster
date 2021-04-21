using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class TokenFacadeTest
    {
        Mock<IUserRepository> userRepository;
        Mock<IHashing> hashingService;
        UserFindByEmailAndPasswordValidator validator;
        User user;
        string userEmail;
        string userPassword;
        UserHashedPassword userHashedPassword;

        [SetUp]
        public void Setup() 
        {
            userRepository = new Mock<IUserRepository>();
            hashingService = new Mock<IHashing>();
            userEmail = UserEmailStub.ByDefault().GetValue();
            userPassword = UserPasswordStub.ByDefault().GetValue();
            validator = new UserFindByEmailAndPasswordValidator();
            userHashedPassword = UserHashedPasswordStub.ByDefault();
        }

        [Test]
        public void TokenFacadeFindUserFromEmailAndPasswordShouldReturnValidUser()
        {
            user = UserStub.ByDefault();
            var tokenFacade = new TokenFacade(userRepository.Object, hashingService.Object, validator);

            userRepository
                .Setup(s => s.FindUserByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>()))
                .Returns(user)
                .Verifiable();
            hashingService
                .Setup(s => s.Hash(It.IsAny<string>()))
                .Returns(userHashedPassword)
                .Verifiable();

            var actual = tokenFacade.FindUserFromEmailAndPassword(
                userEmail,
                userPassword
                );

            Assert.IsNotNull(actual);
            Mock.VerifyAll();
        }

        [Test]
        public void TokenFacadeFindUserFromEmailAndPasswordShouldThrowError()
        {
            user = null;
            var tokenFacade = new TokenFacade(userRepository.Object, hashingService.Object, validator);

            userRepository
                .Setup(s => s.FindUserByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>()))
                .Returns(user);
            hashingService
                .Setup(s => s.Hash(It.IsAny<string>()))
                .Returns(userHashedPassword);

            void dlg() => 
                tokenFacade.FindUserFromEmailAndPassword(
                    userEmail,
                    userPassword
                );
            
            Assert.Throws<UserFoundException>(dlg);
        }
    }
}
