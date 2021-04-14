using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyDomainEvent : DomainEvent
    {
        public DummyDomainEvent(string aggregateId, DomainEventBody body)
            :base(aggregateId, body)
        {
                
        }

        protected override DomainEventRules Rules()
        {
            throw new NotImplementedException();
        }

        protected override void SetResourceManager()
        {
            _resourceManager = new DummyResourceManager();
        }
    }
}
