using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlockBuster.Shared.UI.ContextStartup
{
    public class StartupServiceConfigurationInstaller
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _serviceCollection;

        public IConfiguration GetConfiguration() 
            => _configuration;
        public IServiceCollection GetServiceCollection()
            => _serviceCollection;

        public StartupServiceConfigurationInstaller(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            _serviceCollection = serviceCollection;
            _configuration = configuration;
        }

        public void InstallServicesAlongApp<TInterface>(string contextPrefix = null)
            where TInterface : IStartupContextInstaller
        {

            var paramList = new object[] { this };
            var installers = StartupAssemblyCollectorFacade.GetAssembliesAlongApp<TInterface>(contextPrefix, paramList);                      

            installers.ForEach(installer =>
                installer.InstallServices()
            );
        }
    }
}
