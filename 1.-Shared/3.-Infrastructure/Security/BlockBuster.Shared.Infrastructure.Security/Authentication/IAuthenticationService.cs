using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Security.Authentication
{
    public interface IAuthenticationService
    {

        void SetNameIdentifier(string nameIdentifier);
        string GetNameIdentifier();

    }
}
