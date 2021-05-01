using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Security.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private string _nameIdentifier;

        public AuthenticationService()
        {
            _nameIdentifier = null;
        }

        public void SetNameIdentifier(string nameIdentifier)
        { 
            _nameIdentifier = nameIdentifier;
        }
        public string GetNameIdentifier()
        { 
            return _nameIdentifier;
        }

    }
}
