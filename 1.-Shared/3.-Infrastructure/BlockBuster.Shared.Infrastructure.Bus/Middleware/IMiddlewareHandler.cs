using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public interface IMiddlewareHandler
    {
        IMiddlewareHandler SetNext(IMiddlewareHandler handler);
        IResponse Handle(IRequest request);
    }
}
