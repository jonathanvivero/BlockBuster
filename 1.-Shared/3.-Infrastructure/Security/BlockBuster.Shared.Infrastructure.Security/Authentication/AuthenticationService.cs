using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Security.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private int _n;
        public void Set(int number)
            => _n = number;
        public int Get()
            => _n;
    }
}
