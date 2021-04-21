using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;
using BlockBuster.Shared.Testing.Infrastructure.Resources;
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
            Add(TestingResources.DummyEventDummyField, DataTypeResources.STRING);
        }
    }
}
