using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public abstract class StartupDomainServicesContextInstaller
        : IStartupDomainServicesContextInstaller
    {
        protected readonly StartupServiceConfigurationInstaller _configureServicesInstaller;
        protected StartupDomainServicesContextInstaller(StartupServiceConfigurationInstaller configureServicesInstaller)
        {
            _configureServicesInstaller = configureServicesInstaller;
        }

        public abstract void InstallServices();
    }
}
