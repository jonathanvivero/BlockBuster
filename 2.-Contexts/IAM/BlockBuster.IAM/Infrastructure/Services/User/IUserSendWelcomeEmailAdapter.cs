using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserSendWelcomeEmailAdapter
    {
        IResponse SendUserSignedUpWelcomeEmail(Domain.UserAggregate.User user);
    }
}