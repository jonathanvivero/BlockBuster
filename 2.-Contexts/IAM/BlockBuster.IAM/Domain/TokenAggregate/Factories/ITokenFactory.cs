using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.TokenAggregate.Factories
{
    public interface ITokenFactory
    {
        Token Create(
            IDictionary<string, string> payload
        );
    }
}
