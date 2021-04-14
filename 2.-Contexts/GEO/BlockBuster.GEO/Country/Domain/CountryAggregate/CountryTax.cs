using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class CountryTax : DoubleValueObject
    {                
        public CountryTax(double value) : base(value)
        {            
        }
    }
}
