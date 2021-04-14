using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.Extensions.DependencyInjection;

namespace BlockBuster.IAM.Infrastructure.Services.Startup
{
    public class ApplicationServicesContextConfiguration: StartupApplicationServicesContextInstaller 
    {        
        public ApplicationServicesContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller
                .GetServiceCollection()
                .AddScoped<UserConverter>()
                .AddScoped<TokenConverter>()
                .AddScoped<UserSignUpUseCase>()
                .AddScoped<TokenCreateUseCase>()

                .AddScoped<UserSignUpRequest>()
                .AddScoped<UserSignUpResponse>()
                .AddScoped<TokenCreateRequest>()
                .AddScoped<TokenCreateResponse>()

                //.AddScoped<SendUserWelcomeEmailUseCase>()
                //.AddScoped<SendUserWelcomeEmailWhenUserSignedUpEventHandler>()
                ;
        }
    }
}
