using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.Shared.Infrastructure.Bus.Event
{
    public class DomainEventPublisherSync : IDomainEventPublisher
    {
        private IEventBus eventBus;
        public DomainEventPublisherSync(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }
        public void Publish(DomainEvent domainEvent)
        {
            this.eventBus.Dispatch(domainEvent);
        }
    }
}
