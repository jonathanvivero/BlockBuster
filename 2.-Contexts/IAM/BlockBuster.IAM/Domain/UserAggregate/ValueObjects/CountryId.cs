using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class CountryId : UUID
    {
        public CountryId(string message) : base(message) { }
    }
    
}
