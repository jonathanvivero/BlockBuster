using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Domain.TokenAggregate.Factories;
using BlockBuster.IAM.Domain.TokenAggregate.Repository;
using BlockBuster.IAM.Domain.TokenAggregate.Validators;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockBuster.IAM.Application.UseCases.Token.Create
{
    public class TokenCreateUseCase: IUseCase
    {
        private readonly TokenAdapter _tokenAdapter;
        private readonly ITokenFactory _tokenFactory;
        private readonly ITokenRepository _tokenRepository;
        private readonly TokenCreateValidator _createTokenValidator;
        private readonly TokenConverter _tokenConverter;

        public TokenCreateUseCase(TokenAdapter tokenAdapter,
            ITokenFactory tokenFactory,
            ITokenRepository tokenRepository,
            TokenConverter tokenConverter,
            TokenCreateValidator createTokenValiator)
        {
            _tokenAdapter = tokenAdapter;
            _tokenConverter = tokenConverter;
            _tokenFactory = tokenFactory;
            _tokenRepository = tokenRepository;
            _createTokenValidator = createTokenValiator;

        }
        public IResponse Execute(IRequest req)
        {
            TokenCreateRequest request = req as TokenCreateRequest;

            IDictionary<string, string> payload = _tokenAdapter.FindPayloadFromEmailAndPassword(request.Email, request.Password);

            var token = _tokenFactory.Create(payload);

            _createTokenValidator.Validate(token.UserId);

            _tokenRepository.Add(token);

            return _tokenConverter.Convert(token);
        }
    }
}
