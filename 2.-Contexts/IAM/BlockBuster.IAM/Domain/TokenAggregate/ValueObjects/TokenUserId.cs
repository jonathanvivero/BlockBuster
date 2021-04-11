using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.TokenAggregate.ValueObjects
{
    public class TokenUserId : UUID
    {
        public TokenUserId(string message) : base(message) { }
    }
}
