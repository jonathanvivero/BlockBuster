using BlockBuster.FILM.Category.Application.UseCase.FindById;
using BlockBuster.FILM.Film.Application.UseCase.Create;
using BlockBuster.FILM.Film.Application.UseCase.DispatchCorrectUseCase;
using BlockBuster.FILM.Film.Application.UseCase.FindById;
using BlockBuster.FILM.Film.Application.UseCase.FindByName;
using BlockBuster.FILM.Film.Application.UseCase.GetAll;
using BlockBuster.FILM.Film.Application.UseCase.LookUpFilmInExternalApi;
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
                .AddScoped<DispatchCorrectUseCaseUseCase>()
                .AddScoped<CategoryFindByIdUseCase>()
                .AddScoped<LookUpFilmInExternalApiUseCase>()
                

                .AddScoped<FilmCreateRequest>()
                .AddScoped<FilmFindByIdRequest>()
                .AddScoped<FilmFindByNameRequest>()
                .AddScoped<FilmGetFilmsRequest>()
                .AddScoped<DispatchCorrectUseCaseRequest>()
                .AddScoped<CategoryFindByIdRequest>()
                .AddScoped<LookUpFilmInExternalApiRequest>()

                .AddScoped<FilmCreateResponse>()
                .AddScoped<FilmFindByIdResponse>()
                .AddScoped<FilmFindByNameResponse>()
                .AddScoped<FilmGetFilmsResponse>()
                .AddScoped<DispatchCorrectUseCaseResponse>()
                .AddScoped<CategoryFindByIdResponse>()
                .AddScoped<LookUpFilmInExternalApiResponse>()

                ;
        }
    }
}
