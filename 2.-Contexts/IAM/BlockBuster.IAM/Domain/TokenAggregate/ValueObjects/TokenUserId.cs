using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.TokenAggregate.ValueObjects
{
    public class TokenUserId : UUIDValueObject
    {
        public TokenUserId(string message) : base(message) { }
    }
}
