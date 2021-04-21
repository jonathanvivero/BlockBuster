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
    public class UserEmailTest
    {
        [Test]
        public void ItShouldReturnValidValueObject()
        {
            var email = UserEmailStub.ByDefault().GetValue();

            var actual = new UserEmail(email);

            Assert.AreEqual(actual.GetValue(), email);
        }

        [TestCase("mail")]
        [TestCase("mail@")]
        [TestCase("mail@mail")]
        [TestCase("mail@mail.")]
        [TestCase("mail.com")]
        [TestCase("@mail.com")]
        public void ItShouldThrowExceptionByInvalidFormat(string wrongEmailAddress)
        {           
            void dlg() => new UserRole(wrongEmailAddress);

            Assert.Throws<InvalidAttributeException>(dlg);
        }        
    }
}
