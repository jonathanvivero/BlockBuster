using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserFacade
    {
        UserCountry FindCountryFromCountryCode(string countryCode);
    }
}