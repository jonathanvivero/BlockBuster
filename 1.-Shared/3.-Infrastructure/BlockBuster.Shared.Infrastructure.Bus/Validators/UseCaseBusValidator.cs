using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.Infrastructure.Bus.UseCase.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Validators
{
    public class UseCaseBusValidator
    {
        public void UseCaseExists(IDictionary<string, UseCaseMiddleware> useCases, string useCaseName)
        {
            if (!useCases.ContainsKey(useCaseName))
            {
                throw UseCaseBusUseCaseNotFoundException.UseCaseNotFound(useCaseName);
            }
        }
    }
}
