using BlockBuster.GEO.Country.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate.Events
{
    public class CountryCreatedEvent : DomainEvent
    {
        public CountryCreatedEvent(
            string aggregatId, 
            DomainEventBody body) 
            : base(aggregatId, body, CountryResources.ResourceManager) { }

        protected override DomainEventRules Rules() 
            => new CountryCreatedEventRules(Name());
    }
}
