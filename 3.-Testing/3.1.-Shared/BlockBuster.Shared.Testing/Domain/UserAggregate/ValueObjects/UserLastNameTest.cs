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
    public class UserLastNameTest
    {
        [Test]
        public void ItShouldReturnValidValueObject()
        {
            var name = UserLastNameStub.ByDefault().GetValue();

            var actual = new UserLastName(name);

            Assert.AreEqual(actual.GetValue(), name);
        }

        [TestCase("aa")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ItShouldThrowExceptionByInvalidLength(string name)
        {
            void dlg() => new UserLastName(name);

            Assert.Throws<InvalidAttributeException>(dlg);
        }
    }
}
