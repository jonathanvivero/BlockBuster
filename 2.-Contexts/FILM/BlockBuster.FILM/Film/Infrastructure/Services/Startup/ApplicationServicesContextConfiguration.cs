using BlockBuster.FILM.Film.Application.UseCase.Film.Create;
using BlockBuster.FILM.Film.Application.UseCase.Film.FindById;
using BlockBuster.FILM.Film.Application.UseCase.Film.FindByName;
using BlockBuster.FILM.Film.Application.UseCase.Film.GetAll;
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
                .AddScoped<FilmCreateUseCase>()
                .AddScoped<FilmFindByIdUseCase>()
                .AddScoped<FilmFindByNameUseCase>()
                .AddScoped<FilmGetFilmsUseCase>()

                .AddScoped<FilmCreateRequest>()
                .AddScoped<FilmFindByIdRequest>()
                .AddScoped<FilmFindByNameRequest>()
                .AddScoped<FilmGetFilmsRequest>()

                .AddScoped<FilmCreateResponse>()
                .AddScoped<FilmFindByIdResponse>()
                .AddScoped<FilmFindByNameResponse>()
                .AddScoped<FilmGetFilmsResponse>()

                ;
        }
    }
}
