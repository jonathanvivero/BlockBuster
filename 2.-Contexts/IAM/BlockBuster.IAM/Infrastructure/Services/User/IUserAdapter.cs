using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserAdapter
    {
        UserCountry FindCountryFromCountryCode(string countryCode);
        UserCountry FindCountryFromCountryId(string countryId);
    }
}