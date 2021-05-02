using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Category.Infrastructure.Repositories;
using BlockBuster.FILM.Category.Infrastructure.Services;
using BlockBuster.FILM.Category.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Application.UseCase.GetAll;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Repositories;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Infrastructure.Services.Film;
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
                .AddScoped<FilmRepositoryFilterBuilder>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<FilmConverter>()
                .AddScoped<CategoryConverter>()

                .AddScoped<IFilmFindByFilterLookUpInExternalApiAdapter, FilmFindByFilterLookUpInExternalApiAdapter>()
                .AddScoped<IFilmFindByFilterLookUpInExternalApiFacade, FilmFindByFilterLookUpInExternalApiFacade>()
                .AddScoped<IFilmFindByFilterFindCategoryNameFacade, FilmFindByFilterFindCategoryNameFacade>()                
                .AddScoped<IFilmTranslator, FilmTranslator>()
                .AddScoped<FilmCategoryBinderFacade>()
                .AddScoped<ICategoryTranslator, CategoryTranslator>()

                .AddSingleton<TransactionMiddleware<IBlockBusterFilmContext>>()
                ;


        }
    }
}
