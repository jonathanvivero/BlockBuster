using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class ErrorException : System.Exception
    {
        public ErrorException(string message) : base(message) { }
    }
}
