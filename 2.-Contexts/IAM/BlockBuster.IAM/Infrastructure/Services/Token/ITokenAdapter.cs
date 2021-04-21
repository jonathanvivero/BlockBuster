using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public interface ITokenAdapter
    {
        IDictionary<string, string> FindPayloadFromEmailAndPassword(string email, string password);
    }
}
