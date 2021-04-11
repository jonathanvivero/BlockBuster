using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class WarningException : System.Exception
    {
        public WarningException(string message) : base(message) { }
    }
}
