using BlockBuster.Shared.Application.Bus.Event;
using BlockBuster.Shared.Domain.Events;
using System.Collections.Generic;

namespace BlockBuster.Shared.Infrastructure.Bus.Event
{
    public class EventBusSync : IEventBus
    {
        private IDictionary<string, IDictionary<string, IEventHandler>> eventHandlers;
        public EventBusSync()
        {
            this.eventHandlers = new Dictionary<string, IDictionary<string, IEventHandler>>();

        }
        public void Subscribe(IEventHandler eventHandler, string eventName)
        {
            string className = eventHandler.GetType().ToString();
            IDictionary<string, IEventHandler> eventHandlers =
                new Dictionary<string, IEventHandler>();

            if (this.eventHandlers.ContainsKey(eventName))
            {
                eventHandlers = this.eventHandlers[eventName];
            }

            eventHandlers.Add(className, eventHandler);

            this.eventHandlers.Add(eventName, eventHandlers);
        }

        public void Dispatch(DomainEvent domainEvent)
        {
            string eventName = domainEvent.Name();

            if (!this.eventHandlers.ContainsKey(eventName))
                return;

            IDictionary<string, IEventHandler> domainEvents = this.eventHandlers[eventName];

            foreach (var keyValue in domainEvents)
            {
                keyValue.Value.Handle(domainEvent);
            }
        }
    }
}
