using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Infrastructure.Bus.Event;
using BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy;
using BlockBuster.Shared.Testing.Infrastructure.Resources;
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
        public void DomainEventPublisherShouldDispatchDomainEventOnPublish()
        {
            var eventBusMock = new Mock<IEventBus>();
            var aggregateId = TestingResources.DummyAggregateId;
            var svo = new DummyStringValueObject(TestingResources.DummyEventDummyField);
            var dummyDomainEventBody = new DummyDomainEventBody(svo);
            var domainEvent = new DummyDomainEvent(aggregateId, dummyDomainEventBody);
            
            var domainEventPublisher = new DomainEventPublisherSync(eventBusMock.Object);
            
            eventBusMock
                .Setup(s => s.Dispatch(It.IsAny<DomainEvent>()))
                .Verifiable();

            domainEventPublisher.Publish(domainEvent);

            eventBusMock.Verify();
        }

        [Test]        
        public void DomainEventWithEmptyBodyShouldThrowExceptionOnCreatingDomainEvent()
        {
            var aggregateId = TestingResources.DummyAggregateId;
            var svo = new DummyStringValueObject(string.Empty);
            var dummyDomainEventBody = new DummyDomainEventBody(svo);
            //var domainEvent = new DummyDomainEvent(aggregateId, dummyDomainEventBody);

            void dlg() => new DummyDomainEvent(aggregateId, dummyDomainEventBody);

            Assert.Throws<DomainEventException>(dlg);
        }

    }
}
