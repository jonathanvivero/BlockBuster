using BlockBuster.GEO.Country.Domain.CountryAggregate.Exceptions;
using BlockBuster.GEO.Country.Infrastructure.Resources;
using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class CountryCode : StringValueObject
    {        
        public const int LENGTH = 3;
        public CountryCode(string value) : base(value)
        {
            if (value.Length != LENGTH)
                throw InvalidCountryAttributeException.FromLength(CountryResources.FieldCode, LENGTH);            
        }
    }
}
