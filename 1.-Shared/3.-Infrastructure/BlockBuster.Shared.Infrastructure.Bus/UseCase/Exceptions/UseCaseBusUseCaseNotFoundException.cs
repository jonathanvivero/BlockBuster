using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.UseCase.Exceptions
{
    public class UseCaseBusUseCaseNotFoundException: Exception
    {
        public UseCaseBusUseCaseNotFoundException(string message)
            : base(message)
        {

        }

        public static UseCaseBusUseCaseNotFoundException UseCaseNotFound(string useCaseName)
        {
            return new UseCaseBusUseCaseNotFoundException(string.Format("", useCaseName));
        }
    }
}
