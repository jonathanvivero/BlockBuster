using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class ExceptionMiddleware : MiddlewareHandler
    {
        private readonly ExceptionConverter exceptionConverter;
        public ExceptionMiddleware(ExceptionConverter exceptionConverter)
        {
            this.exceptionConverter = exceptionConverter;
        }

        public override IResponse Handle(IRequest request)
        {
            try
            {
                IResponse response = base.Handle(request);

                return response;
            }
            catch (ValidationException exception)
            {
                return this.exceptionConverter.Convert("400", exception.Message);
            }
            catch (System.Exception exception)
            {
                return this.exceptionConverter.Convert("500", exception.Message);
            }
        }
    }
}
