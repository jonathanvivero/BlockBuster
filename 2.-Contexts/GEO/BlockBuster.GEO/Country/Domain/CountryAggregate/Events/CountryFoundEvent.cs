using BlockBuster.GEO.Country.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate.Events
{
    public class CountryFoundEvent : DomainEvent
    {
        public CountryFoundEvent(string aggregatId, DomainEventBody body) : base(aggregatId, body) { }

        protected override DomainEventRules Rules() 
            => new CountryFoundEventRules(Name());

        protected override void SetResourceManager()
            => _resourceManager = CountryResources.ResourceManager;
    }
}
