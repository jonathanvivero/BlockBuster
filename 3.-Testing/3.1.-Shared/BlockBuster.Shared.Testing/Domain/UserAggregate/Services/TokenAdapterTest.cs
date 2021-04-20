using BlockBuster.IAM.Domain.UserAggregate;
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
            var tokenFacadeMock = new Mock<TokenFacade>();
            var tokenTranslatorMock = new Mock<TokenTranslator>();            
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

        [Test]
        public void TokenAdapterFindPayloadFromEmailAndPasswordShouldTrowErrorByUserNotFound()
        {
            var tokenFacadeMock = new Mock<TokenFacade>();
            var tokenTranslatorMock = new Mock<TokenTranslator>();
            var email = UserEmailStub.ByDefault().GetValue();
            var password = UserHashedPasswordStub.ByDefault().GetValue();
            User user = null; UserStub.ByDefault();
            var payload = PayloadStub.ByDefault();
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
