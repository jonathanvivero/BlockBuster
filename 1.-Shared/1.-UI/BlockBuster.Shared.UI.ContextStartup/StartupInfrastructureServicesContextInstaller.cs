using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public abstract class StartupInfrastructureServicesContextInstaller
        : IStartupInfrastructureServicesContextInstaller
    {
        protected readonly StartupServiceConfigurationInstaller _configureServicesInstaller;
        protected StartupInfrastructureServicesContextInstaller(StartupServiceConfigurationInstaller configureServicesInstaller)
        {
            _configureServicesInstaller = configureServicesInstaller;
        }

        public abstract void InstallServices();
    }
}
