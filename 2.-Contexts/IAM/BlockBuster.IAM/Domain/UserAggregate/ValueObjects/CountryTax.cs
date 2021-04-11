using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class CountryTax : DoubleValueObject
    {                
        public CountryTax(double value) : base(value)
        {            
        }
    }
}
