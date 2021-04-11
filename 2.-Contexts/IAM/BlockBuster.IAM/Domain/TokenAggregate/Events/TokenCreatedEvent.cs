using BlockBuster.IAM.Domain.TokenAggregate.Events.Rules;
using BlockBuster.IAM.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.TokenAggregate.Events
{
    public class TokenCreatedEvent : DomainEvent
    {
        public TokenCreatedEvent(string aggregatId, DomainEventBody body) : base(aggregatId, body) { }

        protected override DomainEventRules Rules()
            => new TokenCreatedEventRules(Name());


        protected override void SetResourceManager()
            => _resourceManager = IAMResources.ResourceManager;

    }
}
