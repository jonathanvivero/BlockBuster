using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyDomainEventRules : DomainEventRules
    {
        public DummyDomainEventRules(string name)
            : base(name)
        {
            Add("test", "string");
        }
    }
}
