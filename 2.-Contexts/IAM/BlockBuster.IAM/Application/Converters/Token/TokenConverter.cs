using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Application.Converters.Token
{
    public class TokenConverter
    {
        public IResponse Convert(Domain.TokenAggregate.Token token)
        {
            return new TokenCreateResponse(token.UserId, token.Hash);
        }
    }
}
