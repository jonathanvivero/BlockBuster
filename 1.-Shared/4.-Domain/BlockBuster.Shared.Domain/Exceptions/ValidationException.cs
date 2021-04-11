using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class ValidationException : WarningException
    {
        public ValidationException(string message) : base(message) { }
    }
}
