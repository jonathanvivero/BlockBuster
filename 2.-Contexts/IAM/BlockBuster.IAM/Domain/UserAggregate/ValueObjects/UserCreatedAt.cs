using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserCreatedAt : DateTimeValueObject
    {
        public UserCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
