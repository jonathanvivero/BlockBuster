using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.UI.ContextStartup;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.IAM.Infrastructure.Services.Startup
{
    public class StartupAIMContextMiddlewareInstaller
        : IStartupContextMiddlewareInstaller
    {
        private readonly StartupApplicationConfigurationInstaller _startupApplicationConfigurationInstaller;
        
        public StartupAIMContextMiddlewareInstaller(
            StartupApplicationConfigurationInstaller startupApplicationConfigurationInstaller
        )
        {
            _startupApplicationConfigurationInstaller = startupApplicationConfigurationInstaller;
        }

        public KeyValuePair<IBlockBusterContext, IList<IMiddlewareHandler>> GetContextMiddlewares()
        {
            var serviceProvider = _startupApplicationConfigurationInstaller
                .GetServiceProvider();
            IBlockBusterIAMContext context = serviceProvider
                .GetService<IBlockBusterIAMContext>();

            IList<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>
            {
                serviceProvider
                    .GetService<TransactionMiddleware<IBlockBusterIAMContext>>()
            };

            var kvMiddlewares = new KeyValuePair<IBlockBusterContext, IList<IMiddlewareHandler>>(
                context, 
                middlewareHandlers                
            );

            return kvMiddlewares;
        }
    }
}
