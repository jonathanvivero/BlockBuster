using BlockBuster.IAM.Domain.TokenAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Infrastructure.Presistence.Repositories;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.IAM.Infrastructure.Services.Startup
{
    public class InfrastructureServicesContextConfiguration: StartupInfrastructureServicesContextInstaller
    {        
        public InfrastructureServicesContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller
                .GetServiceCollection()

                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITokenRepository, TokenRepository>()                

                .AddScoped<UserAdapter>()
                .AddScoped<UserFacade>()
                .AddScoped<TokenAdapter>()
                .AddScoped<TokenFacade>()
                .AddScoped<TokenTranslator>()

                .AddSingleton<TransactionMiddleware<IBlockBusterIAMContext>>()
                ;


        }
    }
}
