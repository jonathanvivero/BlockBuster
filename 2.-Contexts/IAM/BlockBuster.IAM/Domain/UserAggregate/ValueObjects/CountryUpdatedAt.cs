using BlockBuster.Shared.Domain.ValueObjects;
using System;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class CountryUpdatedAt : DateTimeValueObject
    {
        public CountryUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
