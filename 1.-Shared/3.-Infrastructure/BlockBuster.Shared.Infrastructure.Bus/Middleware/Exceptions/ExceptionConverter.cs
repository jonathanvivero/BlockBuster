using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions
{
    public class ExceptionConverter
    {
        public IResponse Convert(string code, string message)
        {
            return new ExceptionResponse(code, message);
        }
    }
}
