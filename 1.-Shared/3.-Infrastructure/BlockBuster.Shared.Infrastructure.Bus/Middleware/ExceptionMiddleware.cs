using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class ExceptionMiddleware : MiddlewareHandler
    {
        private readonly ExceptionConverter _exceptionConverter;
        public ExceptionMiddleware(ExceptionConverter exceptionConverter)
        {
            _exceptionConverter = exceptionConverter;
        }

        public override IResponse Handle(IRequest request)
        {
            try
            {
                IResponse response = base.Handle(request);

                return response;
            }
            catch (ContentException exception)
            {
                return _exceptionConverter.Convert("204", exception.Message);
            }
            catch (ValidationException exception)
            {
                return _exceptionConverter.Convert("400", exception.Message);
            }
            catch (AuthorizationException exception)
            {
                return _exceptionConverter.Convert("401", exception.Message);
            }
            catch (ForbiddenException exception)
            {
                return _exceptionConverter.Convert("403", exception.Message);
            }
            catch (System.Exception exception)
            {
                return _exceptionConverter.Convert("500", exception.Message);
            }
        }
    }
}
