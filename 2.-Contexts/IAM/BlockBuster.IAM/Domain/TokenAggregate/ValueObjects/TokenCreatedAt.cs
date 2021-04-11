using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.IAM.Domain.TokenAggregate.ValueObjects
{
    public class TokenCreatedAt : DateTimeValueObject
    {
        public TokenCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
