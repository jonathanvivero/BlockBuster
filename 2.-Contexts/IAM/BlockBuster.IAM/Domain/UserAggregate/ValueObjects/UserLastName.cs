using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserLastName : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;
        public UserLastName(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
                throw InvalidUserAttributeException.FromMinLength(UserResources.FieldLastName, MIN_LENGTH);

            if (value.Length > MAX_LENGTH)
                throw InvalidUserAttributeException.FromMaxLength(UserResources.FieldLastName, MAX_LENGTH);
        }
    }
}
