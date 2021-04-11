using BlockBuster.IAM.Domain.UserAggregate.Events.Rules;
using BlockBuster.IAM.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.IAM.Domain.UserAggregate.Events
{
    public class CountryFoundEvent : DomainEvent
    {
        public CountryFoundEvent(string aggregatId, DomainEventBody body) : base(aggregatId, body) { }

        protected override DomainEventRules Rules() 
            => new CountryFoundEventRules(Name());

        protected override void SetResourceManager()
            => _resourceManager = IAMResources.ResourceManager;
    }
}
