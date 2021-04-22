using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Testing.Infrastructure.Resources;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyDomainEventBody : DomainEventBody
    {
        public DummyDomainEventBody(DummyStringValueObject svo)
        {
            
            Add<string>(TestingResources.DummyEventDummyField, svo);
        }
    }
}
