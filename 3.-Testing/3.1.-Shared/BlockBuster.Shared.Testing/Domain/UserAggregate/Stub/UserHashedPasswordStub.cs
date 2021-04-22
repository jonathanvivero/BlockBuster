using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserHashedPasswordStub
    {
        public static UserHashedPassword Create(string pass)
        {
            var hasher = new DefaultHashing();
            return hasher.Hash(pass);
        }

        public static UserHashedPassword ByDefault()
        {
            return Create("123456789");
        }
    }
}