using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class InvalidUUIDException : InvalidAttributeException
    {
        public InvalidUUIDException(string message) : base(message) { }
    }
}
