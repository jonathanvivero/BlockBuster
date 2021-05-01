using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class UseCaseValidationMiddleware : MiddlewareHandler
    {
        private IUseCaseValidator _useCaseValidator;        

        public UseCaseValidationMiddleware(IUseCaseValidator useCaseValidator)
        {
            _useCaseValidator = useCaseValidator;
        }

        public override IResponse Handle(IRequest request)
        { 
            _useCaseValidator.Validate(request);

            return base.Handle(request);
        }

    }
}
