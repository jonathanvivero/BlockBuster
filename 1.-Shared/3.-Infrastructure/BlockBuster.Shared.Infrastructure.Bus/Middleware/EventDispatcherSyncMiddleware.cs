using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Bus.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class EventDispatcherSyncMiddleware : MiddlewareHandler
    {
        private IEventProvider eventProvider;
        private IDomainEventPublisher domainEventPublisher;

        public EventDispatcherSyncMiddleware(
            IEventProvider eventProvider,
            IDomainEventPublisher domainEventPublisher)
        {
            this.eventProvider = eventProvider;
            this.domainEventPublisher = domainEventPublisher;
        }

        public override IResponse Handle(IRequest request)
        {
            IResponse response = base.Handle(request);

            var domainEvents = this.eventProvider.ReleaseEvents();

            foreach (var domainEvent in domainEvents)
                this.domainEventPublisher.Publish(domainEvent);

            return response;
        }
    }
}
