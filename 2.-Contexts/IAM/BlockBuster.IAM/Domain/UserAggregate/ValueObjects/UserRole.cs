using BlockBuster.Shared.Domain.ValueObjects;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserRole : StringValueObject
    {
        public static string ROLE_USER = UserResources.ROLE_USER;
        public static string ROLE_ADMIN = UserResources.ROLE_ADMIN;

        public UserRole(string value) : base(value)
        {
            if (value != ROLE_ADMIN && value != ROLE_USER)
                throw InvalidUserAttributeException.FromText(UserResources.ValidationRoleIsNotValid);
        }        
    }
}
