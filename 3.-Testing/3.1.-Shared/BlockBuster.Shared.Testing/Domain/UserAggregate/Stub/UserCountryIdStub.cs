using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserCountryIdStub
    {
        public static UserCountryId Create(string id)
        {
            return new UserCountryId(id);
        }

        public static UserCountryId ByDefault()
        {
            return Create("ec72259e-60bf-4b46-b6f6-7f27d713d50b");
        }
    }
}