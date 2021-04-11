using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class MiddlewareHandler : IMiddlewareHandler
    {
        private IMiddlewareHandler nextHandler;
        public IMiddlewareHandler SetNext(IMiddlewareHandler handler)
        {
            this.nextHandler = handler;
            return this.nextHandler;
        }

        public virtual IResponse Handle(IRequest request)
        {
            return this.nextHandler.Handle(request);
        }
    }
}
