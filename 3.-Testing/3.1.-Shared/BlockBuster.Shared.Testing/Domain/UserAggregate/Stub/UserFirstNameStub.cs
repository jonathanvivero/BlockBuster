using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserFirstNameStub
    {
        public static UserFirstName Create(string name)
        {
            return new UserFirstName(name);
        }

        public static UserFirstName ByDefault()
        {
            return Create("Manuel");
        }
    }
}