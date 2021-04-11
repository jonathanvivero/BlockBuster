using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class CountryCode : StringValueObject
    {        
        public const int LENGTH = 3;
        public CountryCode(string value) : base(value)
        {
            if (value.Length != LENGTH)
                throw InvalidUserAttributeException.FromLength(CountryResources.FieldCode, LENGTH);            
        }
    }
}
