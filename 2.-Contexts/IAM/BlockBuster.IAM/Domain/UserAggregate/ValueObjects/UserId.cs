using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserId : UUIDValueObject
    {
        public UserId(string message) : base(message) { }
    }
    
}
