using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events
{
    public interface IEventProvider
    {
        void RecordEvents(IList<DomainEvent> domainEvents);
        IList<DomainEvent> ReleaseEvents();
    }
}
