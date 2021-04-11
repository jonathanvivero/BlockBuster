using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public abstract class StringValueObject : ValueObject<string>
    {
        public StringValueObject(string value) : base(value)
        {
        }

    }
}
