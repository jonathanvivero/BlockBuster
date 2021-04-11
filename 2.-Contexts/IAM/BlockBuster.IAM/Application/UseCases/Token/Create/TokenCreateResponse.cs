using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Application.UseCases.Token.Create
{
    public class TokenCreateResponse : IResponse
    {
        public string UserId { get; }
        public string Hash { get; }
        public TokenCreateResponse(TokenUserId userId, TokenHash hash)
        {
            this.UserId = userId.GetValue();
            this.Hash = hash.GetValue();
        }
    }
}
