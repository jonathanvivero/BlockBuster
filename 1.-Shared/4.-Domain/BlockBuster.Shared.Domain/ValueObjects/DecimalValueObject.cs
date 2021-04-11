using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public abstract class DecimalValueObject : ValueObject<decimal>
    {        
        public DecimalValueObject(decimal value): base(value)
        { }      

    }
}
