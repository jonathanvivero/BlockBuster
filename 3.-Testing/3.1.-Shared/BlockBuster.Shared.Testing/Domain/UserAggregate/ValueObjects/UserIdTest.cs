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
    public class UserIdTest
    {
        [Test]
        public void ItShouldReturnValidValueObject()
        {
            var id = UserIdStub.ByDefault().GetValue();

            var actual = new UserId(id);

            Assert.AreEqual(actual.GetValue(), id);
        }

        [Test]
        public void ItShouldThrowExceptionByEmpty()
        {
            var id = "";

            void dlg() => new UserId(id);

            Assert.Throws<InvalidAttributeException>(dlg);
        }

        [Test]
        public void ItShouldThrowExceptionByBadFormat()
        {
            var id = "123456789123456789123456789";

            void dlg() => new UserId(id);

            Assert.Throws<InvalidAttributeException>(dlg);
        }
    }
}
