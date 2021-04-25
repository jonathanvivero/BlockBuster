using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class CountryId : UUIDValueObject
    {
        public CountryId(string message) : base(message) { }
    }
    
}
