using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyDomainEventBody : DomainEventBody
    {
        public DummyDomainEventBody()
        {
            var svo = new StringValueObject(string.Empty);
            Add("test", typeof(StringValueObject));
        }
    }
}
