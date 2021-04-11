using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public abstract class IntegerValueObject : ValueObject<int>
    {
        public IntegerValueObject(int value) : base(value) { }
    }
}
