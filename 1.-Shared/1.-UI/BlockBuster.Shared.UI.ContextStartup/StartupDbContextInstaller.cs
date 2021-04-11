using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public abstract class StartupDbContextInstaller: IStartupDbContextInstaller
    {
        protected readonly StartupServiceConfigurationInstaller _configureServicesInstaller;
        protected StartupDbContextInstaller(StartupServiceConfigurationInstaller configureServicesInstaller)
        {
            _configureServicesInstaller = configureServicesInstaller;
        }

        public abstract void InstallServices();        
    }
}
