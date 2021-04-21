using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public interface ITokenFacade
    {
        Domain.UserAggregate.User FindUserFromEmailAndPassword(string email, string password);
    }
}
