using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Bus.Event;
using BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event
{
    public class DomainEventPublisherSyncTest
    {
        [Test]
        public void DomainEventPublisherShouldDispatchDomainEventOnPublisf()
        {
            var eventBusMock = new Mock<IEventBus>();
            var aggregateId = "1";
            var dummyDomainEventBody = new DummyDomainEventBody();
            var domainEvent = new DummyDomainEvent(aggregateId, dummyDomainEventBody);
            
            var domainEventPublisher = new DomainEventPublisherSync(eventBusMock.Object);
            
            eventBusMock
                .Setup(s => s.Dispatch(It.IsAny<DomainEvent>()))
                .Verifiable();

            domainEventPublisher.Publish(domainEvent);

            eventBusMock.Verify();
        }

    }
}
