using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class Exception : System.Exception
    {
        public Exception(string message) : base(message) { }
    }
}
