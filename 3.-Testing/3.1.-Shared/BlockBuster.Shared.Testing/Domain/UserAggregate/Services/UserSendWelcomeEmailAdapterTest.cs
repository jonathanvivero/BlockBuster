using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class UserSendWelcomeEmailAdapterTest
    {
        [Test]
        public void UserSendWelcomeEmailAdapterShouldUseCollaborators()
        {
            Mock<IUserSendWelcomeEmailFacade> userSendWelcomeEmailAdapterMock =
                new Mock<IUserSendWelcomeEmailFacade>();
            SendUserWelcomeEmailResponse response = new SendUserWelcomeEmailResponse();
            UserSendWelcomeEmailAdapter userSendWelcomeEmailAdapter =
                new UserSendWelcomeEmailAdapter(userSendWelcomeEmailAdapterMock.Object);
            User user = UserStub.ByDefault();
            userSendWelcomeEmailAdapterMock
                .Setup(s => s.SendUserSignedUpWelcomeEmail(It.IsAny<User>()))
                .Returns(response)
                .Verifiable();

            userSendWelcomeEmailAdapter.SendUserSignedUpWelcomeEmail(user);

            userSendWelcomeEmailAdapterMock.Verify();
        }
    }
}
