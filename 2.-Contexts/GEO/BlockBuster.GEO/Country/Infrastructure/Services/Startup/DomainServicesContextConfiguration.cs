using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.GEO.Country.Infrastructure.Services.Factories;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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

                .AddScoped<ICountryFactory, CountryFactory>();
        }
    }
}
