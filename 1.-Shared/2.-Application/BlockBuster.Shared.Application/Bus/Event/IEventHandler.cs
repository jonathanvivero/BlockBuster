using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.Shared.Application.Bus.Event
{
    public interface IEventHandler
    {
        void Handle(DomainEvent domainEvent);
        string[] SubscribeTo();
    }
}
