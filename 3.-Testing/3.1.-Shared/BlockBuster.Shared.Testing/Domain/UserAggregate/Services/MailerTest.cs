using BlockBuster.IAM.Infrastructure.Services.Mailer;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class MailerTest
    {

        [Test]
        public void MailerShouldUseCollaborator()
        {
            var configurationMock = new Mock<IConfiguration>();
            var configurationSectionMock = new Mock<IConfigurationSection>();
            configurationSectionMock.Setup(s => s.Value)
                .Returns<string>(null);
            configurationMock.Setup(s => s.GetSection(It.IsAny<string>()))
                .Returns(configurationSectionMock.Object)
                .Verifiable();

            var mailer = new DefaultMailer(configurationMock.Object);

            configurationMock.Verify();

        }
    }
}
