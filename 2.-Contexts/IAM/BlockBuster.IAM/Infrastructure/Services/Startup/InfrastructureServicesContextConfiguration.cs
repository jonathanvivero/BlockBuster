using BlockBuster.IAM.Domain.TokenAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Infrastructure.Factory;
using BlockBuster.IAM.Infrastructure.Presistence.Repositories;
using BlockBuster.IAM.Infrastructure.Services.Mailer;
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

                .AddScoped<IUserAdapter, UserAdapter>()
                .AddScoped<IUserFacade, UserFacade>()
                .AddScoped<IUserTranslator, UserTranslator>()
                .AddScoped<IUserSendWelcomeEmailAdapter, UserSendWelcomeEmailAdapter>()
                .AddScoped<IUserSendWelcomeEmailFacade, UserSendWelcomeEmailFacade>()
                .AddScoped<ITokenAdapter, TokenAdapter>()
                .AddScoped<ITokenFacade, TokenFacade>()
                .AddScoped<ITokenTranslator, TokenTranslator>()
                
                .AddScoped<IMailer, DefaultMailer>()
                .AddScoped<MailTemplateFactory>()



                .AddSingleton<TransactionMiddleware<IBlockBusterIAMContext>>()
                ;


        }
    }
}
