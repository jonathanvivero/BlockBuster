using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Shared.UI.ContextStartup;

namespace BlockBuster.Main.StartupBuilder
{


    public class DbContextConfigurationFacade
    {
        private const string CONTEXT_PREFIX = "BlockBuster";
        private readonly StartupServiceConfigurationInstaller _configureServiceInstaller;
        
        public DbContextConfigurationFacade(StartupServiceConfigurationInstaller configureServiceInstaller)
        {
            _configureServiceInstaller = configureServiceInstaller;            
        }

        public void ConfigureDbContexts()
        {
            _configureServiceInstaller.InstallServicesAlongApp<IStartupDbContextInstaller>(CONTEXT_PREFIX);

        }

       
    }
}
