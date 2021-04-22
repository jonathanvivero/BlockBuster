using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class CountryCreatedAt : DateTimeValueObject
    {
        public CountryCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
