using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;

namespace BlockBuster.GEO.Country.Infrastructure.Services.Factories
{
    public class CountryFactory: ICountryFactory
    {
        public Domain.CountryAggregate.Country Create(string id,
            string code,
            double tax,
            DateTime createdAt,
            DateTime updatedAt)
        {
            var countryId = new CountryId(id);
            var countryCode = new CountryCode(code);
            var countryTax = new CountryTax(tax);
            var countryCreatedAt = new CountryCreatedAt(createdAt);
            var countryUpdatedAt = new CountryUpdatedAt(updatedAt);

            return Domain.CountryAggregate.Country.Create(countryId, countryCode, countryTax, countryCreatedAt, countryUpdatedAt);
        }
    }
}
