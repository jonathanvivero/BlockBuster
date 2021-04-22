using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockBuster.Main.StartupBuilder;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.Main
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            StartupServiceConfigurationInstaller configureServiceInstaller =
                new StartupServiceConfigurationInstaller(services, Configuration);

            AuthenticationConfigurationFacade authenticationConfigurationFacade =
                new AuthenticationConfigurationFacade(configureServiceInstaller);

            DbContextConfigurationFacade dbContextConfigurationFacade =
                new DbContextConfigurationFacade(configureServiceInstaller);

            StartupServiceCollectionInstallerFacade servicesInstallerFacade = 
                new StartupServiceCollectionInstallerFacade(configureServiceInstaller);

            authenticationConfigurationFacade
                .ConfigureAuthenticationServices();

            dbContextConfigurationFacade
                .ConfigureDbContexts();


            servicesInstallerFacade
                .ConfigureOptionsServices()
                .ConfigureApplicationServices()
                .ConfigureDomainServices()
                .ConfigureInfrastructureServices()
                .ConfigureMvcServices()
                .ConfigureApiServices()
                .ConfigureSwaggerServices();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider, IServiceProvider serviceProvider)
        {

            StartupApplicationConfigurationInstaller applicationConfigurationInstaller =
                new StartupApplicationConfigurationInstaller(
                    app, 
                    provider, 
                    serviceProvider
                );

            applicationConfigurationInstaller
                .AddUseCaseBusSubscriptions()
                .AddEventBusSubscriptions()
                .UseSwagger()
                .ConfigureApp(env.IsDevelopment());            
        }
    }
}
