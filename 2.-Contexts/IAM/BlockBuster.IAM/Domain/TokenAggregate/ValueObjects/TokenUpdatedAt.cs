using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.IAM.Domain.TokenAggregate.ValueObjects
{
    public class TokenUpdatedAt : DateTimeValueObject
    {
        public TokenUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
