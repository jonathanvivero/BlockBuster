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
    public class UserRoleTest
    {
        [Test]
        public void RoleAsUserItShouldReturnValidValueObject()
        {
            var role = UserRoleStub.ByDefault().GetValue();
            
            var actual = new UserRole(role);

            Assert.AreEqual(actual.GetValue(), role);
        }

        [Test]
        public void RoleAsAdminItShouldReturnValidValueObject()
        {
            var role = UserRoleStub.AsAdmin().GetValue();

            var actual = new UserRole(role);

            Assert.AreEqual(actual.GetValue(), role);
        }

        [Test]
        public void ItShouldThrowExceptionByNotExistingRole()
        {
            var role = "wrong_role";

            void dlg() => new UserRole(role);

            Assert.Throws<InvalidAttributeException>(dlg);
        }
        
    }
}
