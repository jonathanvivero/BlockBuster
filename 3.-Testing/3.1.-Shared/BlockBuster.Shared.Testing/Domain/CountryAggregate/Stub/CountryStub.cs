using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub
{
    public class CountryStub
    {
        public static Country Create(CountryId id, CountryCode code, CountryTax tax, CountryCreatedAt createdAt, CountryUpdatedAt updatedAt)
        {
            return Country.Create(
                id,
                code,
                tax,
                createdAt,
                updatedAt
            );
        }
        public static Country ByDefault()
        {
            return Create(
                CountryIdStub.ByDefault(),
                CountryCodeStub.ByDefault(),
                CountryTaxStub.ByDefault(),
                CountryCreatedAtStub.ByDefault(),
                CountryUpdatedAtStub.ByDefault()
                );
        }
    }
}
