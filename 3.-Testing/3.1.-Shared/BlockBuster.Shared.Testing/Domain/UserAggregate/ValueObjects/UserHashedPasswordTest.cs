using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.ValueObjects
{
    [TestFixture]
    public class UserHashedTest
    {
        [Test]
        public void ItShouldReturnValidValueObject()
        {
            var password = UserHashedPasswordStub.ByDefault().GetValue();

            var actual = new UserHashedPassword(password);

            Assert.AreEqual(actual.GetValue(), password);
        }

        [TestCase("")]        
        public void ItShouldThrowExceptionByBadPattern(string password)
        {
            void dlg() => new UserHashedPassword(password);

            Assert.DoesNotThrow(dlg);
        }
    }
}
