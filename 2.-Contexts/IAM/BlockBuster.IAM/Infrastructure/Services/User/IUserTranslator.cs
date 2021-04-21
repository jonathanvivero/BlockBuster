using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserTranslator
    {
        UserCountry FromFindCountryByCodeResponseToUserCountry(IResponse resp);
    }
}