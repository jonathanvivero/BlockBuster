using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
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
    public class UserCountryTest
    {
        [Test]
        public void ItShouldReturnValidValueObject()
        {
            var country = UserCountryStub.ByDefault().GetValue();

            var actual = new UserCountry(country);

            Assert.AreEqual(actual.GetValue().Code.GetValue(), country.Code.GetValue());
            Assert.AreEqual(actual.GetValue().Id.GetValue(), country.Id.GetValue());
        }

        [Test]
        public void ItShouldThrowExceptionByNullCountry()
        {

            void dlg() => new UserCountry(null);

            Assert.Throws<InvalidUserAttributeException>(dlg);
        }
    }
}
