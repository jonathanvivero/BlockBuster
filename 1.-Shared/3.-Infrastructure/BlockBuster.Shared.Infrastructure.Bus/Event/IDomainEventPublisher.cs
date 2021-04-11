using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Event
{
    public interface IDomainEventPublisher
    {
        void Publish(DomainEvent domainEvent);
    }
}
