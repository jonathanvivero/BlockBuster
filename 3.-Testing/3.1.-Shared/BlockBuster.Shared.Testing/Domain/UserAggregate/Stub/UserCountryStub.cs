using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserCountryStub
    {
        public static UserCountry Create(Country country)
        {
            return new UserCountry(country);
        }

        public static UserCountry ByDefault()
        {
            return Create(CountryStub.ByDefault());
        }
    }
}