using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserCountryId : UUIDValueObject
    {
        public UserCountryId(string message) : base(message) { }
    }
    
}
