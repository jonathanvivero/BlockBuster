using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public interface IStartupContextMiddlewareInstaller
    {
        KeyValuePair<IBlockBusterContext, IList<IMiddlewareHandler>> GetContextMiddlewares();
    }
}
