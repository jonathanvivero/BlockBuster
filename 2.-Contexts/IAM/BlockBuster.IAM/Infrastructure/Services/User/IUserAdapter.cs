using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System.Collections.Generic;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserAdapter
    {
        UserCountry FindCountryFromCountryCode(string countryCode);
        UserCountry FindCountryFromCountryId(string countryId);
        IEnumerable<UserCountry> GetUserCountries();
    }
}