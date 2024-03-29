﻿using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Category.Domain.FilmAggregate.Validators;
using BlockBuster.FILM.Category.Infrastructure.Services.Factories;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Domain.FilmAggregate.Events;
using BlockBuster.FILM.Film.Domain.FilmAggregate.Validators;
using BlockBuster.FILM.Film.Infrastructure.Services.Factories;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.GEO.Country.Infrastructure.Services.Startup
{
    public class DomainServicesContextConfiguration: StartupDomainServicesContextInstaller 
    {        
        public DomainServicesContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller
                .GetServiceCollection()

                .AddScoped<IFilmFactory, FilmFactory>()
                .AddScoped<FilmFromExternalAPIValidator>()

                .AddScoped<ICategoryFactory, CategoryFactory>()
                .AddScoped<CategoryExistenceValidator>();
        }
    }
}
