using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System.Collections.Generic;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserFacade
    {
        UserCountry FindCountryFromCountryCode(string countryCode);
        UserCountry FindCountryFromCountryId(string countryId);
        IEnumerable<UserCountry> GetCountries();
    }
}