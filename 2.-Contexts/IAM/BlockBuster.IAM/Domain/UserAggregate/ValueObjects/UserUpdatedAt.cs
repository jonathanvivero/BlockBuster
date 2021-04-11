using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserUpdatedAt : DateTimeValueObject
    {
        public UserUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
