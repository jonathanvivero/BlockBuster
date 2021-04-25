using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class AuthorizationException : WarningException
    {
        public AuthorizationException(string message) : base(message) { }
    }
}
