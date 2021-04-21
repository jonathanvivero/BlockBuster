using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserSendWelcomeEmailFacade
    {
        IResponse SendUserSignedUpWelcomeEmail(Domain.UserAggregate.User user);
    }
}