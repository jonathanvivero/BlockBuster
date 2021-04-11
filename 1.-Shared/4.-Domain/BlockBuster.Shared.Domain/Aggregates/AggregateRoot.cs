using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Aggregates
{
    public abstract class AggregateRoot
    {
        protected IList<DomainEvent> _events;

        public AggregateRoot()
        {
            _events = new List<DomainEvent>();
        }

        protected void Record(DomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public IList<DomainEvent> ReleaseEvents()
        {
            IList<DomainEvent> events = (List<DomainEvent>)_events;
            this.RemoveEvents();

            return events;
        }

        private void RemoveEvents()
        {
            _events = new List<DomainEvent>();
        }

    }
}
