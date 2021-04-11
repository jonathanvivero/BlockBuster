using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public abstract class DoubleValueObject : ValueObject<double>
    {
        public DoubleValueObject(double value) : base(value)
        { }
    }
}
