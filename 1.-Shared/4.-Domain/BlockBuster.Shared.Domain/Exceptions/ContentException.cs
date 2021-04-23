using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class ForbiddenException : WarningException
    {
        public ForbiddenException(string message) : base(message) { }
    }
}
