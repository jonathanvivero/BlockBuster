using BlockBuster.GEO.Country.Application.Converters;
using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.GEO.Country.Infrastructure.Repositories;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.GEO.Country.Infrastructure.Services.Startup
{
    public class InfrastructureServicesContextConfiguration: StartupInfrastructureServicesContextInstaller
    {        
        public InfrastructureServicesContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller
                .GetServiceCollection()

                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<CountryConverter>()

                .AddSingleton<TransactionMiddleware<IBlockBusterCountryContext>>()
                ;


        }
    }
}
