using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyDomainEvent : DomainEvent
    {
        public DummyDomainEvent(string aggregateId, DomainEventBody body)
            :base(aggregateId, body, new DummyResourceManager())
        {            
        }

        protected override DomainEventRules Rules()
            => new DummyDomainEventRules(Name());
                
    }
}
