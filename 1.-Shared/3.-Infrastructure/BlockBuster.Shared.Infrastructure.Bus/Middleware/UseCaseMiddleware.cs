using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class UseCaseMiddleware : MiddlewareHandler
    {
        private IUseCase _useCase;        

        public UseCaseMiddleware(IUseCase useCase)
        {
            _useCase = useCase;
        }

        public override IResponse Handle(IRequest request)
            => _useCase.Execute(request);
        public string GetContextName() 
            => _useCase.GetContextName();

    }
}
