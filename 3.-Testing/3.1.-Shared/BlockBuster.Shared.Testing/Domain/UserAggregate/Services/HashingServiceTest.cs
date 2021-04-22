using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class HashingServiceTest
    {
        [Test]
        public void DefaultHashingServiceShouldReturnEncriptedPassword()
        {
            DefaultHashing service = new DefaultHashing();
            var password = UserPasswordStub.ByDefault().GetValue();
            var actual = service.Hash(password);

            Assert.IsInstanceOf<UserHashedPassword>(actual);
            Assert.AreNotEqual(password, actual.GetValue());

        }
    }
}
