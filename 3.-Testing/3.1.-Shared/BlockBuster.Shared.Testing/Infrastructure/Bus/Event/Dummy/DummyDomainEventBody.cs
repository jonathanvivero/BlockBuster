using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.Shared.Testing.Infrastructure.Bus.Event.Dummy
{
    internal class DummyDomainEventBody : DomainEventBody
    {
        public DummyDomainEventBody()
        {
            var svo = new DummyStringValueObject(string.Empty);
            Add<string>("test", svo);
        }
    }
}
