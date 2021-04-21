using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
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
    public class TokenAdapterTest
    {
        [Test]
        public void TokenAdapterFindPayloadFromEmailAndPasswordShouldUseCollaborators() 
        {
            var tokenFacadeMock = new Mock<ITokenFacade>();
            var tokenTranslatorMock = new Mock<ITokenTranslator>();            
            var email = UserEmailStub.ByDefault().GetValue();
            var password = UserHashedPasswordStub.ByDefault().GetValue();
            var user = UserStub.ByDefault();            
            var payload = PayloadStub.Create(user);
            var tokenAdapter = new TokenAdapter(
                tokenFacadeMock.Object,
                tokenTranslatorMock.Object);

            tokenFacadeMock
                .Setup(s => s.FindUserFromEmailAndPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user)
                .Verifiable();
            tokenTranslatorMock.Setup(s => s.FromRepresentationToPayLoad(It.IsAny<User>()))
                .Returns(payload)
                .Verifiable();

            var actual = tokenAdapter.FindPayloadFromEmailAndPassword(email, password);

            tokenFacadeMock.Verify();
            tokenTranslatorMock.Verify();
        }
    }
}
