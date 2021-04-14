using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Startup
{
    public class DBContextConfiguration: StartupDbContextInstaller
    {

        public DBContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller.GetServiceCollection()
               .AddDbContextPool<IBlockBusterIAMContext, BlockBusterIAMContext>(
                   options =>
                   {
                       options.UseMySql(_configureServicesInstaller
                           .GetConfiguration()
                           .GetConnectionString("DefaultConnection")
                        );
                   }
               )
               .AddSingleton<IBlockBusterIAMContext, BlockBusterIAMContext>();
        }
    }
}
