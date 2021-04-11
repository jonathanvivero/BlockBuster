using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.TokenAggregate.Events.Body
{
    public class TokenCreatedEventBody: DomainEventBody
    {
        public TokenCreatedEventBody(Token token)
        {
            Add(TokenResources.FieldHash, token.Hash);
            Add(TokenResources.FieldUserId, token.UserId);
            Add(TokenResources.FieldCreatedAt, token.CreatedAt);
            Add(TokenResources.FieldUpdatedAt, token.UpdatedAt);            
        }
    }
}
