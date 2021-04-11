using BlockBuster.Shared.Application.Bus.Event;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.Shared.Infrastructure.Bus.Event
{
    public interface IEventBus
    {
        void Subscribe(IEventHandler eventHandler, string eventName);
        void Dispatch(DomainEvent domainEvent);
    }
}
