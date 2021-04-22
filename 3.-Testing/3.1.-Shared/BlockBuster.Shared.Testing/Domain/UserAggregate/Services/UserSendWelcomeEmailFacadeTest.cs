using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class UserSendWelcomeEmailFacadeTest
    {
        [Test]
        public void SendUserSignedUpWelcomeEmailShouldUseCollaborators()
        {
            Mock<IUseCaseBus> useCaseBusMock = new Mock<IUseCaseBus>();
            var userSendWelcomeEmailFacade = new UserSendWelcomeEmailFacade(useCaseBusMock.Object);
            var user = UserStub.ByDefault();
            IRequest request = new SendUserWelcomeEmailRequest(
                user.Email.GetValue(),
                user.FirstName.GetValue(),
                user.LastName.GetValue());
            IResponse response = new SendUserWelcomeEmailResponse();
            useCaseBusMock
                .Setup(s => s.Dispatch(It.IsAny<IRequest>()))
                .Returns(response)
                .Verifiable();

            var actual = userSendWelcomeEmailFacade.SendUserSignedUpWelcomeEmail(user);

            Assert.IsNotNull(actual);
            useCaseBusMock.Verify();

        }
    }
}
