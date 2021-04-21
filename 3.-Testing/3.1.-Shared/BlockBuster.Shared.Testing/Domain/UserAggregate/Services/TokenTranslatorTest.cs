using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class TokenTranslatorTest
    {
        [Test]
        public void FromRepresentationToPayLoadShouldReturnDictionary()
        {
            var tokenTranslator = new TokenTranslator();
            var user = UserStub.ByDefault();
            var actual = tokenTranslator.FromRepresentationToPayLoad(user);

            Assert.AreEqual(actual[TokenResources.PayloadUsedId], user.Id.GetValue());
            Assert.AreEqual(actual[TokenResources.PayloadEmail], user.Email.GetValue());
        }

        [Test]
        public void FromRepresentationToPayLoadShouldThrowError()
        {
            var tokenTranslator = new TokenTranslator();
            User user = null;
            void dlg() => tokenTranslator.FromRepresentationToPayLoad(user);

            Assert.Throws<NullReferenceException>(dlg);
        }
    }
}
