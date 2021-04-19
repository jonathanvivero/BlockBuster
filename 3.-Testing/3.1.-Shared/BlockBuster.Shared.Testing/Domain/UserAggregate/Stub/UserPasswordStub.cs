using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserPasswordStub
    {
        public static UserPassword Create(string pass)
        {            
            return new UserPassword(pass);
        }

        public static UserPassword ByDefault()
        {
            return Create("Aa123456789");
        }
        public static UserPassword WrongPattern()
        {
            return Create("123456789");
        }

        public static UserPassword DifferentToDefault()
        {
            return Create("123456789Aa");
        }
    }
}