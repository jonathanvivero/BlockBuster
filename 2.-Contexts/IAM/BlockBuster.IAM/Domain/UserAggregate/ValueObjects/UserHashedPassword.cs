using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserHashedPassword : StringValueObject
    {
        public UserHashedPassword(string value) : base(value) { }
    }
}
