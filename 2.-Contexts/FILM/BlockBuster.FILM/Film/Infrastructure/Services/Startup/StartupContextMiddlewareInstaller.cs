using BlockBuster.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using BlockBuster.Shared.UI.ContextStartup;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;

namespace BlockBuster.GEO.Country.Infrastructure.Services.Startup
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
            IBlockBusterFilmContext context = serviceProvider
                .GetService<IBlockBusterFilmContext>();

            IList<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>
            {
                serviceProvider
                    .GetService<TransactionMiddleware<IBlockBusterFilmContext>>()
            };

            var kvMiddlewares = new KeyValuePair<IBlockBusterContext, IList<IMiddlewareHandler>>(
                context, 
                middlewareHandlers                
            );

            return kvMiddlewares;
        }
    }
}
