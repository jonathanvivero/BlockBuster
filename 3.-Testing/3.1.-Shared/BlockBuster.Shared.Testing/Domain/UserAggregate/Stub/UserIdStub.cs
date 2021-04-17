using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserIdStub
    {
        public static UserId Create(string id)
        {
            return new UserId(id);
        }

        public static UserId ByDefault()
        {
            return Create("64d63087-003f-48a5-9cad-2fbffcc3b8be");
        }
    }
}