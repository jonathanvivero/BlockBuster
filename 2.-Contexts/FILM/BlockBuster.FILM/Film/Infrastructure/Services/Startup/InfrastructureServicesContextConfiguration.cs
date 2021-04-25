using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Repositories;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
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

                .AddScoped<IFilmRepository, FilmRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<FilmConverter>()
                .AddScoped<CategoryConverter>()

                .AddSingleton<TransactionMiddleware<IBlockBusterFilmContext>>()
                ;


        }
    }
}
