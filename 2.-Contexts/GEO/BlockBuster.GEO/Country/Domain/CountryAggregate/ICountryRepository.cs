using System.Collections.Generic;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public interface ICountryRepository
    {        
        Country FindByCode(CountryCode countryCode);
    }
}
