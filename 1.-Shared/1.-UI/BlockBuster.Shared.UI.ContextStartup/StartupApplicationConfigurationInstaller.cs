using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.Event;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.Event;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public class StartupApplicationConfigurationInstaller
    {

        private readonly IApplicationBuilder _applicationBuilder;
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceCollection _serviceCollection;

        public IApplicationBuilder GetApplicationBuilder() 
            => _applicationBuilder;
        public IApiVersionDescriptionProvider GetApiVersionDescriptionProvider()
            => _apiVersionDescriptionProvider;
        public IServiceProvider GetServiceProvider()
            => _serviceProvider;
        
        public StartupApplicationConfigurationInstaller(IApplicationBuilder applicationBuilder, 
            IApiVersionDescriptionProvider apiVersionDescriptionProvider,
            IServiceProvider serviceProvider)
        {
            _applicationBuilder = applicationBuilder;
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
            _serviceProvider = serviceProvider;
        }

        public StartupApplicationConfigurationInstaller AddUseCaseBusSubscriptions()
        {
            IUseCaseBus useCaseBus = _serviceProvider.GetService<IUseCaseBus>();

            var useCaseInterfaceType = typeof(IUseCase);
            var useCases = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => useCaseInterfaceType.IsAssignableFrom(p)
                    && !p.IsInterface && !p.IsAbstract
                    && p.Name != UseCaseResources.UseCaseInterfaceName);

            foreach (Type useCase in useCases)
            {
                useCaseBus.Subscribe((IUseCase)_serviceProvider.GetService(useCase));
            }
                
            IDictionary<string, IList<IMiddlewareHandler>> contextMiddlewares =
                GetContextMiddlewareAlongApp<IStartupContextMiddlewareInstaller>();

            IList<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>()
            {
                //_serviceProvider.GetService<TransactionMiddleware>(),
                _serviceProvider.GetService<EventDispatcherSyncMiddleware>(),
                _serviceProvider.GetService<ExceptionMiddleware>()
            };

            useCaseBus.SetContextMiddlewares(contextMiddlewares);
            useCaseBus.SetMiddlewares(middlewareHandlers);
            

            return this;
        }

        public StartupApplicationConfigurationInstaller AddEventBusSubscriptions()
        {
            IEventBus eventBus = _serviceProvider.GetService<IEventBus>();
            var eventHandlerInterfaceType = typeof(IEventHandler);
            var eventHandlers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => eventHandlerInterfaceType.IsAssignableFrom(p)
                    && p.Name != EventBusResources.EventHandlerInterfaceName);

            foreach (Type eventHandler in eventHandlers)
            {
                IEventHandler eventHandlerService = (IEventHandler)_serviceProvider.GetService(eventHandler);
                foreach (string subscribeTo in eventHandlerService.SubscribeTo())
                {
                    eventBus.Subscribe(eventHandlerService, subscribeTo);
                }
            }

            return this;
        }

        public StartupApplicationConfigurationInstaller UseSwagger()
        {
            _applicationBuilder.UseSwagger();
            _applicationBuilder.UseSwaggerUI(options =>
            {
                foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return this;
        }

        public StartupApplicationConfigurationInstaller ConfigureApp(bool isDevelopment = true)
        {
            if (isDevelopment)
                _applicationBuilder.UseDeveloperExceptionPage();
            else
                _applicationBuilder.UseHsts();

            _applicationBuilder.UseHttpsRedirection();
            _applicationBuilder.UseCors("AllowAllOrigins");
            _applicationBuilder.UseAuthentication();
            _applicationBuilder.UseMvc();

            return this;
        }

        public IDictionary<string, IList<IMiddlewareHandler>> GetContextMiddlewareAlongApp<TInterface>(string contextPrefix = null)
            where TInterface : IStartupContextMiddlewareInstaller
        {
            var paramList = new object[] { this };
            var installers = StartupAssemblyCollectorFacade.GetAssembliesAlongApp<TInterface>(contextPrefix, paramList);

            var contextMiddlewareHandlers = installers
                .Select(s => s.GetContextMiddlewares())
                .ToDictionary(
                    k => k.Key
                        .GetType()
                        .FullName
                        .Split('.')
                        .LastOrDefault(), 
                    v => v.Value);
            
            return contextMiddlewareHandlers;
        }
    }
}
