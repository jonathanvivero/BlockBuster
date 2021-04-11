using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserId : UUID
    {
        public UserId(string message) : base(message) { }
    }
    
}
