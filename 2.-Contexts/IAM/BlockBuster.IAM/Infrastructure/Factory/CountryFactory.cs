using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Factory
{
    public class CountryFactory : ICountryFactory
    {

        public Country Create(string id,
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

            return new Country(countryId, countryCode, countryTax, countryCreatedAt, countryUpdatedAt);
        }

    }
}
