using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserLastNameStub
    {
        public static UserLastName Create(string name)
        {
            return new UserLastName(name);
        }

        public static UserLastName ByDefault()
        {
            return Create("García");
        }
    }
}