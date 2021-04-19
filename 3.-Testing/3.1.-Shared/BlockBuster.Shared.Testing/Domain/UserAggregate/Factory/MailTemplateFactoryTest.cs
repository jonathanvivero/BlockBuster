using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Text;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using BlockBuster.IAM.Infrastructure.Templates.Mail;
using System.Linq;
using BlockBuster.IAM.Infrastructure.Factory;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Factory
{
    [TestFixture]
    public class MailTemplateFactoryTest
    {

        [Test]
        public void CreateUserSignedUpWelcomeEmailShouldReturnValidTemplate()
        {
            var factory = new MailTemplateFactory();
            var user = UserStub.ByDefault();
            var userEmail = user.Email.GetValue();
            var userSignedUpWelcomeEmailTemplate = factory.CreateUserSignedUpWelcomeEmail(
                userEmail,
                user.FirstName.GetValue(),
                user.LastName.GetValue()
                );

            Assert.IsTrue(userSignedUpWelcomeEmailTemplate.Receivers().Contains(userEmail));
        }
    }
}
