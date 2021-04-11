using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions
{
    public class ExceptionResponse : IResponse
    {
        public ExceptionResponse(string code, string message)
        {
            this.Code = code;
            this.message = message;
        }

        public string Code { get; private set; }
        public string message { get; private set; }
    }
}
