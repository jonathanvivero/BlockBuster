using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using System.Collections.Generic;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public class TokenTranslator: ITokenTranslator
    {
        public TokenTranslator()
        {

        }

        public IDictionary<string, string> FromRepresentationToPayLoad(Domain.UserAggregate.User user)
        {
            return new Dictionary<string, string>()
            {
                [TokenResources.PayloadUsedId] = user.Id.GetValue(),
                [TokenResources.PayloadRole] = user.Role.GetValue(),
                ["roles"] = user.Role.GetValue(),
                [TokenResources.PayloadCountryCode] = user.Country.GetValue().Code.GetValue(),
                [TokenResources.PayloadCountryId] = user.Country.GetValue().Id.GetValue(),
                [TokenResources.PayloadEmail] = user.Email.GetValue(),
                [TokenResources.PayloadFirstName] = user.FirstName.GetValue(),
                [TokenResources.PayloadLastName] = user.LastName.GetValue()
            };

        }
    }
}
