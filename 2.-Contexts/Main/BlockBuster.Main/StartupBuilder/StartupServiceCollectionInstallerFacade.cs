using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Bus.Event;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.Validators;
using BlockBuster.Shared.Infrastructure.Resources;
using BlockBuster.Shared.Infrastructure.Security.Authentication.JWT;
using BlockBuster.Shared.UI.ContextStartup;
using JsonApiSerializer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockBuster.Main.StartupBuilder
{
    public class StartupServiceCollectionInstallerFacade
    {
        private readonly StartupServiceConfigurationInstaller _serviceConfigurationInstaller;
        public StartupServiceCollectionInstallerFacade(StartupServiceConfigurationInstaller serviceConfigurationInstaller)
        {
            _serviceConfigurationInstaller = serviceConfigurationInstaller;
        }

        public StartupServiceCollectionInstallerFacade ConfigureOptionsServices()
        {
            _serviceConfigurationInstaller
                .GetServiceCollection()
                .AddOptions();

            return this;
        }

        public StartupServiceCollectionInstallerFacade ConfigureApplicationServices()
        {
            _serviceConfigurationInstaller
                .GetServiceCollection()
                .AddScoped<ExceptionConverter>();

            _serviceConfigurationInstaller.
                InstallServicesAlongApp<IStartupApplicationServicesContextInstaller>();

            return this;
        }

        public StartupServiceCollectionInstallerFacade ConfigureDomainServices()
        {
            _serviceConfigurationInstaller.
                InstallServicesAlongApp<IStartupDomainServicesContextInstaller>();

            return this;
        }

        public StartupServiceCollectionInstallerFacade ConfigureInfrastructureServices()
        {
            _serviceConfigurationInstaller.
                GetServiceCollection()
                .AddScoped<IHashing, DefaultHashing>()
                .AddScoped<IJWTEncoder, JWTEncoder>()
                .AddScoped<IEventProvider, EventProvider>()
                .AddScoped<IDomainEventPublisher, DomainEventPublisherSync>()
                .AddScoped<IEventBus, EventBusSync>()
                .AddScoped<UseCaseMiddleware>()
                .AddScoped<EventDispatcherSyncMiddleware>()
                .AddScoped<ExceptionMiddleware>();

            _serviceConfigurationInstaller.
                GetServiceCollection()
                .AddSingleton<UseCaseBusValidator>()
                .AddSingleton<IUseCaseBus, UseCaseBus>()
                ;
                //.AddSingleton<TransactionMiddleware>();

            _serviceConfigurationInstaller.
                InstallServicesAlongApp<IStartupInfrastructureServicesContextInstaller>();

            return this;
        }

        
        public StartupServiceCollectionInstallerFacade ConfigureMvcServices()
        {
            _serviceConfigurationInstaller.
                GetServiceCollection()
                .AddMvcCore()
                .AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");

            var sp = _serviceConfigurationInstaller.
                GetServiceCollection()
                .BuildServiceProvider();

            var loggerFactory = sp.GetService<ILoggerFactory>();
            var objectPoolProvider =  sp.GetService<ObjectPoolProvider>();            

            _serviceConfigurationInstaller.
                GetServiceCollection()
                .AddMvc((opt) =>
                {
                    var serializerSettings = new JsonApiSerializerSettings();

                    var jsonApiFormatter = new JsonOutputFormatter(serializerSettings, ArrayPool<Char>.Shared);
                    opt.OutputFormatters.RemoveType<JsonOutputFormatter>();
                    opt.OutputFormatters.Insert(0, jsonApiFormatter);

                    var logger = loggerFactory.CreateLogger<JsonInputFormatter>();
                    var jsonMvcOptions = new MvcJsonOptions()
                    {
                        AllowInputFormatterExceptionMessages = true
                    };

                    var jsonApiInputFormatter = new JsonInputFormatter(
                        logger,
                        serializerSettings,
                        ArrayPool<Char>.Shared,
                        objectPoolProvider,
                        opt, jsonMvcOptions);                    

                    opt.InputFormatters.RemoveType<JsonInputFormatter>();
                    opt.InputFormatters.Insert(0, jsonApiInputFormatter);
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return this;
        }

        public StartupServiceCollectionInstallerFacade ConfigureApiServices()
        {
            _serviceConfigurationInstaller
                .GetServiceCollection()
                .AddApiVersioning(config =>
                {
                    config.ReportApiVersions = true;
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.ApiVersionReader = new HeaderApiVersionReader(
                        new string[] { ConfigurationEntryResources.ApiVersion }
                    );
                });

            return this;
        }

        public StartupServiceCollectionInstallerFacade ConfigureSwaggerServices()
        {
            var serviceCollection =
            _serviceConfigurationInstaller
                .GetServiceCollection();

                serviceCollection.AddSwaggerGen(options =>
                {
                    options.AddSecurityDefinition(
                        ConfigurationEntryResources.SecurityDefinitioOAuth2, 
                        new ApiKeyScheme()
                        {
                            Description = ConfigurationEntryResources.ApiKeySchemeDescription,
                            In = ConfigurationEntryResources.ApiKeySchemeIn,
                            Name = ConfigurationEntryResources.ApiKeySchemeName,
                            Type = ConfigurationEntryResources.ApiKeySchemeType
                        }
                    );

                    options.OperationFilter<SecurityRequirementsOperationFilter>();

                    var provider = serviceCollection.BuildServiceProvider()
                        .GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new Info()
                            {
                                Title = string.Format(
                                    ConfigurationEntryResources.SampleApiDescriptionFormat, 
                                    description.ApiVersion
                                ), Version = description.ApiVersion.ToString()
                            }
                        );
                    }
                });

            return this;
        }
    }
}
