using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class CountryId : UUID
    {
        public CountryId(string message) : base(message) { }
    }
    
}
