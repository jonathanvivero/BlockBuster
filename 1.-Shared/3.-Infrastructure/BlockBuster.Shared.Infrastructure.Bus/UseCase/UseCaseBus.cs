using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.Extensions;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.Infrastructure.Bus.UseCase.Exceptions;
using BlockBuster.Shared.Infrastructure.Bus.Validators;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;

namespace BlockBuster.Shared.Infrastructure.Bus.UseCase
{
    public class UseCaseBus
         : IUseCaseBus
    {
        private IDictionary<string, UseCaseMiddleware> _useCases;
        private IList<IMiddlewareHandler> _middlewareHandlers;
        private IDictionary<IBlockBusterContext, IList<IMiddlewareHandler>> _contextMiddlewareHandlers;
        private readonly UseCaseBusValidator _useCaseBusValidator;

        public UseCaseBus(UseCaseBusValidator useCaseBusValidator)
        {
            _contextMiddlewareHandlers = new Dictionary<IBlockBusterContext, IList<IMiddlewareHandler>>();
            _useCaseBusValidator = useCaseBusValidator;
            _useCases = new Dictionary<string, UseCaseMiddleware>();
        }

        public void SetMiddlewares(IList<IMiddlewareHandler> middlewareHandlers)
        {
            _middlewareHandlers = middlewareHandlers;
        }

        public void SetContextMiddlewares(IDictionary<IBlockBusterContext, IList<IMiddlewareHandler>> contextMiddlewareHandlers)            
        {
            _contextMiddlewareHandlers = contextMiddlewareHandlers;
        }

        public void Subscribe(IUseCase useCase)
        {
            string className = useCase.GetType().ToString();
            _useCases.Add(className, new UseCaseMiddleware(useCase));
        }

        public IResponse Dispatch(IRequest req, IBlockBusterContext context = null)
        {
            IMiddlewareHandler handler;
            string useCaseName = req.GetUseCaseName();

            _useCaseBusValidator.UseCaseExists(_useCases, useCaseName);

            handler = _useCases[useCaseName];

            if (context != null && _contextMiddlewareHandlers.ContainsKey(context))
            {
                var middlewareHandlers = _contextMiddlewareHandlers[context];
                foreach (IMiddlewareHandler middlewareHandler in middlewareHandlers)
                {
                    middlewareHandler.SetNext(handler);
                    handler = middlewareHandler;
                }
            }

            foreach (IMiddlewareHandler middlewareHandler in _middlewareHandlers)
            {
                middlewareHandler.SetNext(handler);
                handler = middlewareHandler;
            }

            return handler.Handle(req);
        }

        public IResponse Dispatch<TContext>(IRequest req, TContext context)
            where TContext : IBlockBusterContext
        {
            IMiddlewareHandler handler;
            string useCaseName = req.GetUseCaseName();

            _useCaseBusValidator.UseCaseExists(_useCases, useCaseName);

            handler = _useCases[useCaseName];

            foreach (IMiddlewareHandler middlewareHandler in _middlewareHandlers)
            {
                middlewareHandler.SetNext(handler);
                handler = middlewareHandler;
            }

            foreach (IMiddlewareHandler middlewareHandler in _middlewareHandlers)
            {
                middlewareHandler.SetNext(handler);
                handler = middlewareHandler;
            }

            return handler.Handle(req);
        }



    }
}
