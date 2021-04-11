using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class UseCaseMiddleware : MiddlewareHandler
    {
        private IUseCase useCase;

        public UseCaseMiddleware(IUseCase useCase)
        {
            this.useCase = useCase;
        }

        public override IResponse Handle(IRequest request)
        {
            return useCase.Execute(request);
        }
    }
}
