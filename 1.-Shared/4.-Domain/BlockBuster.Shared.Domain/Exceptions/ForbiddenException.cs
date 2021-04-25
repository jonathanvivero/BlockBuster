using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class ContentException : WarningException
    {
        public ContentException(string message) : base(message) { }
    }
}
