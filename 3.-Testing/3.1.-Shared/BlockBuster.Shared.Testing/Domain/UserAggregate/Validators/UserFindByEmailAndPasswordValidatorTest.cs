using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Validators
{
    [TestFixture]
    public class UserFindByEmailAndPasswordValidatorTest
    {
        [Test]
        public void UserFindByEmailAndPasswordValidatorShouldValidateValidUser()
        {
            var validator = new UserFindByEmailAndPasswordValidator();
            User user = UserStub.ByDefault();
            void dlg() => validator.Validate(user);

            Assert.DoesNotThrow(dlg);
        }


        [Test]
        public void UserFindByEmailAndPasswordValidatorShouldThrowErrorNullUser()
        {
            var validator = new UserFindByEmailAndPasswordValidator();
            User user = null;
            void dlg() => validator.Validate(user);

            Assert.Throws<UserFoundException>(dlg);
        }
    }
}
