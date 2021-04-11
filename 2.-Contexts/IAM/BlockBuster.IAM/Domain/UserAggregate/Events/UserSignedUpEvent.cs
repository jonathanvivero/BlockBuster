using BlockBuster.IAM.Domain.UserAggregate.Events.Rules;
using BlockBuster.IAM.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Events
{
    public class UserSignedUpEvent : DomainEvent
    {
        public UserSignedUpEvent(string aggregatId, DomainEventBody body) : base(aggregatId, body) { }

        protected override DomainEventRules Rules()
            => new UserSignedUpEventRules(Name());


        protected override void SetResourceManager()
            => _resourceManager = IAMResources.ResourceManager;
    }
}
