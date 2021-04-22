using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public interface ITokenTranslator
    {
        IDictionary<string, string> FromRepresentationToPayLoad(Domain.UserAggregate.User user);
    }
}
