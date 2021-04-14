using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    public class DummyStringValueObject : StringValueObject
    {
        public DummyStringValueObject(string value)
            :base(value)
        {

        }
    }
}
