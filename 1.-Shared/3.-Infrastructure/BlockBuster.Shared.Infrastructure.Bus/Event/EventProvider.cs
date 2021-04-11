using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Event
{
    public class EventProvider : IEventProvider
    {
        private IList<DomainEvent> events;
        public EventProvider()
        {
            this.RemoveEvents();
        }

        public void RecordEvents(IList<DomainEvent> domainEvents)
        {
            foreach (DomainEvent domainEvent in domainEvents)
            {
                this.Record(domainEvent);
            }
        }

        public IList<DomainEvent> ReleaseEvents()
        {
            var events = this.events;
            this.RemoveEvents();

            return events;
        }

        private void Record(DomainEvent domainEvent)
        {
            this.events.Add(domainEvent);
        }

        private void RemoveEvents()
        {
            this.events = new List<DomainEvent>();
        }
    }
}
