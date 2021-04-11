using BlockBuster.IAM.Domain.TokenAggregate.Exceptions;
using BlockBuster.IAM.Domain.TokenAggregate.Repository;
using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;

namespace BlockBuster.IAM.Domain.TokenAggregate.Validators
{
    public class TokenCreateValidator
    {
        private ITokenRepository tokenRepository;

        public TokenCreateValidator(ITokenRepository userRepository)
        {
            this.tokenRepository = userRepository;
        }

        public void Validate(TokenUserId tokenUserId)
        {
            var token = this.tokenRepository.FindTokenByUserId(tokenUserId);

            if (token != null)
            {
                throw TokenFoundException.FromExistingUserId();
            }
        }
    }
}
