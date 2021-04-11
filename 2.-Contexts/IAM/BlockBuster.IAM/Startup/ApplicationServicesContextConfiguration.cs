using BlockBuster.IAM.Application.Converters.Country;
using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Application.UseCases.Country.Find;
using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Startup
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
                .AddScoped<CountryConverter>()
                .AddScoped<UserSignUpUseCase>()
                .AddScoped<TokenCreateUseCase>()
                .AddScoped<FindCountryByCodeUseCase>()

                .AddScoped<UserSignUpRequest>()
                .AddScoped<UserSignUpResponse>()
                .AddScoped<TokenCreateRequest>()
                .AddScoped<TokenCreateResponse>()
                .AddScoped<FindCountryByCodeRequest>()
                .AddScoped<FindCountryByCodeResponse>()

                //.AddScoped<SendUserWelcomeEmailUseCase>()
                //.AddScoped<SendUserWelcomeEmailWhenUserSignedUpEventHandler>()
                ;
        }
    }
}
