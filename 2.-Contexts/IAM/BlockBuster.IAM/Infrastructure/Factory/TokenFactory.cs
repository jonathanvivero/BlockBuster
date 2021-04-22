using BlockBuster.IAM.Domain.TokenAggregate.Factories;
using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Resources;
using BlockBuster.Shared.Infrastructure.Security.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Factory
{
    public class TokenFactory : ITokenFactory
    {
        private IJWTEncoder _jwtEncoder;

        public TokenFactory(IJWTEncoder jwtEncoder)
        {
            _jwtEncoder = jwtEncoder;
        }

        public Domain.TokenAggregate.Token Create(IDictionary<string, string> payload)
        {
            string hash = _jwtEncoder.Encode(payload);
            TokenHash tokenHash = new TokenHash(hash);
            TokenUserId tokenUserId = new TokenUserId(payload[IAMResources.TokenPayloadUserId]);

            return Domain.TokenAggregate.Token.Create(tokenUserId, tokenHash);
        }
    }
}
