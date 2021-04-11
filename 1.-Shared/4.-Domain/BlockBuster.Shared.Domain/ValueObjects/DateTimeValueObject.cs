using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public abstract class DateTimeValueObject : ValueObject<DateTime>
    {
        public DateTimeValueObject(DateTime value) : base(value)
        { }              
    }

}
