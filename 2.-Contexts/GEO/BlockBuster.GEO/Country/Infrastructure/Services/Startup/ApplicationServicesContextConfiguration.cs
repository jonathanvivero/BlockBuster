using BlockBuster.GEO.Country.Application.Converters;
using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Application.UseCase.GetAll;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.GEO.Country.Infrastructure.Services.Startup
{
    public class ApplicationServicesContextConfiguration: StartupApplicationServicesContextInstaller 
    {        
        public ApplicationServicesContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller
                .GetServiceCollection()                
                .AddScoped<FindCountryByCodeUseCase>()
                .AddScoped<FindCountryByIdUseCase>()
                .AddScoped<CountryGetCountriesUseCase>()

                .AddScoped<FindCountryByCodeRequest>()
                .AddScoped<FindCountryByIdRequest>()
                .AddScoped<CountryGetCountriesRequest>()

                .AddScoped<FindCountryByCodeResponse>()
                .AddScoped<CountryGetCountriesResponse>()
                ;
        }
    }
}
