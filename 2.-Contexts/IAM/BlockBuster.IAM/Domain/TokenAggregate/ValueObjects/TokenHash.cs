using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.TokenAggregate.ValueObjects
{
    public class TokenHash : StringValueObject
    {
        public TokenHash(string value) : base(value) { }
    }
}
