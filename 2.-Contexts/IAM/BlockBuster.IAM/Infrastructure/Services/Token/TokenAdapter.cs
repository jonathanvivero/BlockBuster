using BlockBuster.IAM.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public class TokenAdapter : ITokenAdapter
    {
        private readonly ITokenFacade _tokenFacade;
        private readonly ITokenTranslator _tokenTranslator;
        public TokenAdapter(
            ITokenFacade tokenFacade,
            ITokenTranslator tokenTranslator)
        {
            _tokenFacade = tokenFacade;
            _tokenTranslator = tokenTranslator;
        }

        public IDictionary<string, string> FindPayloadFromEmailAndPassword(string email, string password)
        {
            var user = _tokenFacade.FindUserFromEmailAndPassword(email, password);
            return _tokenTranslator.FromRepresentationToPayLoad(user);
        }
    }
}
