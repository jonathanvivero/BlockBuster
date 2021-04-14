using BlockBuster.GEO.Country.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate.Exceptions
{
    public class CountryNotFoundException: Exception
    {
        public CountryNotFoundException(string message)  
            : base(message)
        {
            
        }

        public static CountryNotFoundException CountryCodeNotFound(string countryCode)
        {
            return new CountryNotFoundException(
                string.Format(CountryResources.ErrorCountryNotFoundByCode, countryCode));

        }
    }
}
