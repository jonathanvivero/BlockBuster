using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.ValueObjects
{
    [TestFixture]
    public class UserPasswordTest
    {
        [Test]
        public void ItShouldReturnValidValueObject()
        {
            var password = UserPasswordStub.ByDefault().GetValue();

            var actual = new UserPassword(password);

            Assert.AreEqual(actual.GetValue(), password);
        }

        [TestCase("123")]
        [TestCase("a123")]
        [TestCase("Aa123")]
        [TestCase("123456789012345678901234567890")]        
        public void ItShouldThrowExceptionByBadPattern(string password)
        {
            void dlg() => new UserPassword(password);

            Assert.Throws<InvalidAttributeException>(dlg);
        }
        [Test]
        public void ValidateShouldReturnThatAreEquals()
        {
            var password1 = UserPasswordStub.ByDefault().GetValue();
            var password2 = UserPasswordStub.ByDefault().GetValue();

            Assert.DoesNotThrow(() => UserPassword.Validate(password1, password2));
        }
        [Test]
        public void ValidateShouldThrowErrorNotEquals()
        {
            string password1 = UserPasswordStub.ByDefault().GetValue();
            password1 = new string(password1
                .ToCharArray()
                .OrderBy(s => s)
                .ToArray());
            string password2 = new string(password1
                .ToCharArray()
                .OrderByDescending(s => s)
                .ToArray());

            Assert.Throws<InvalidUserAttributeException>(() => UserPassword.Validate(password1, password2));
        }
    }
}


