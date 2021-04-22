using BlockBuster.IAM.Domain.TokenAggregate.Events;
using BlockBuster.IAM.Domain.TokenAggregate.Events.Body;
using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using BlockBuster.Shared.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.IAM.Domain.TokenAggregate
{
    public class Token : AggregateRoot
    {
        [Key]
        public TokenUserId UserId { get; private set; }
        public TokenHash Hash { get; private set; }
        public TokenCreatedAt CreatedAt { get; private set; }
        public TokenUpdatedAt UpdatedAt { get; private set; }

        public Token() { }
        private Token(TokenUserId tokenUserId,
            TokenHash tokenHash,
            TokenCreatedAt tokenCreatedAt,
            TokenUpdatedAt tokenUpdatedAt)
        {
            this.UserId = tokenUserId;
            this.Hash = tokenHash;
            this.CreatedAt = tokenCreatedAt;
            this.UpdatedAt = tokenUpdatedAt;
        }

        public static Token Create(TokenUserId tokenUserId, TokenHash tokenHash)
        {
            TokenCreatedAt tokenCreatedAt = new TokenCreatedAt(DateTime.Now);
            TokenUpdatedAt tokenUpdatedAt = new TokenUpdatedAt(DateTime.Now);

            Token token = new Token(tokenUserId, tokenHash, tokenCreatedAt, tokenUpdatedAt);

            token.Record(
                new TokenCreatedEvent(
                    token.UserId.GetValue(),
                    new TokenCreatedEventBody(token)
                )
            );

            return token;
        }
    }
}
