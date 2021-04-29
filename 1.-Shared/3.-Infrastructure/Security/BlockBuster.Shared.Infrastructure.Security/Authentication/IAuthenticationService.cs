using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Security.Authentication
{
    public interface IAuthenticationService
    {

        void Set(int number);
        int Get();
    }
}
