using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Application.Events.User;
using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.IAM.Application.UseCases.User.GetUsers;
using BlockBuster.IAM.Application.UseCases.User.PartialUpdate;
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
                .AddScoped<UserGetUsersConverter>()                

                .AddScoped<UserSignUpUseCase>()
                .AddScoped<TokenCreateUseCase>()
                .AddScoped<SendUserWelcomeEmailUseCase>()
                .AddScoped<UserPartialUpdateUseCase>() 
                .AddScoped<UserGetUsersUseCase>() 

                .AddScoped<SendUserWelcomeEmailWhenUserSignedUpEventHandler>()

                .AddScoped<UserSignUpRequest>()
                .AddScoped<TokenCreateRequest>()
                .AddScoped<SendUserWelcomeEmailRequest>()
                .AddScoped<UserPartialUpdateRequest>()
                .AddScoped<UserGetUsersRequest>()

                .AddScoped<UserSignUpResponse>()
                .AddScoped<TokenCreateResponse>()
                .AddScoped<SendUserWelcomeEmailResponse>()
                .AddScoped<UserPartialUpdateResponse>()
                .AddScoped<UserGetUsersResponse>()
                ;
        }
    }
}
