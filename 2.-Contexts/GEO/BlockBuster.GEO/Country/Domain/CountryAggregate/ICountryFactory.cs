using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public interface ICountryFactory
    {
        Country Create(
           string id,
           string code,
           double tax,
           DateTime createdAt,
           DateTime updatedAt
           );
    }
}
