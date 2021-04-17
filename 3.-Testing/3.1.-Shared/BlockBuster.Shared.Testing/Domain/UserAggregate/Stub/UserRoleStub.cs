using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserRoleStub
    {
        public static UserRole Create(string name)
        {
            return new UserRole(name);
        }

        public static UserRole ByDefault()
        {
            return Create(UserRole.ROLE_USER);
        }

        public static UserRole AsAdmin()
        {
            return Create(UserRole.ROLE_ADMIN);
        }
        
    }
}