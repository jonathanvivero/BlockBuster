using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class CountryUpdatedAt : DateTimeValueObject
    {
        public CountryUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
