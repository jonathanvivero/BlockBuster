using BlockBuster.Shared.Domain.ValueObjects;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserRole : StringValueObject
    {
        public const string ROLE_USER = "User";
        public const string ROLE_ADMIN = "Admin";

        public UserRole(string value) : base(value)
        {
            if (value != ROLE_ADMIN && value != ROLE_USER)
                throw InvalidUserAttributeException.FromText(UserResources.ValidationRoleIsNotValid);
        }        
    }
}
