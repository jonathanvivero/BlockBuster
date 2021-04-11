using System.Collections.Generic;

namespace BlockBuster.Shared.Infrastructure.Security.Authentication.JWT
{
    public interface IJWTEncoder
    {
        string Encode(IDictionary<string, string> payload);
    }
}