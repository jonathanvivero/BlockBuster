using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.UseCase
{
    public interface IUseCaseBus
    {
        void SetMiddlewares(IList<IMiddlewareHandler> middlewareHandlers);
        void SetContextMiddlewares(IDictionary<string, IList<IMiddlewareHandler>> contextMiddlewareHandlers);        
        void Subscribe(IUseCase useCase);
        IResponse Dispatch(IRequest req);

    }
}
