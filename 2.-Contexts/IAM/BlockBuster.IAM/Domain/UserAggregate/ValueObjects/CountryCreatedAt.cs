using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class CountryCreatedAt : DateTimeValueObject
    {
        public CountryCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
