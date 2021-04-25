using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.GEO.Country.Infrastructure.Services.Startup
{
    public class DBContextConfiguration: StartupDbContextInstaller
    {

        public DBContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller.GetServiceCollection()
               .AddDbContextPool<IBlockBusterFilmContext, BlockBusterFilmContext>(
                   options =>
                   {
                       options.UseMySql(_configureServicesInstaller
                           .GetConfiguration()
                           .GetConnectionString("DefaultConnection")
                        );
                   }
               )
               .AddSingleton<IBlockBusterFilmContext, BlockBusterFilmContext>();
        }
    }
}
