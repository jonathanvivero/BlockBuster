using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.TokenAggregate.Events.Rules
{
    public class TokenCreatedEventRules: DomainEventRules
    {
        public TokenCreatedEventRules(string name) : base(name)
        {
            
            Add(TokenResources.FieldHash, DataTypeResources.STRING);
            Add(TokenResources.FieldUserId, DataTypeResources.STRING);
            Add(TokenResources.FieldCreatedAt, DataTypeResources.DATETIME);
            Add(TokenResources.FieldUpdatedAt, DataTypeResources.DATETIME);
        }
    }
}
