using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.TokenAggregate.Repository
{
    public interface ITokenRepository
    {
        void Add(Token token);
        Token FindTokenByUserId(TokenUserId userId);
    }
}
