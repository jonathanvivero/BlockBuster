using BlockBuster.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Application.Bus.UseCase
{
    public interface IUseCase
    {
        IResponse Execute(IRequest req);

        string GetContextName();
    }
}
