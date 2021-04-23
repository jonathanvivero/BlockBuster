using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.IAM.Domain.TokenAggregate.Factories;
using BlockBuster.IAM.Domain.TokenAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Infrastructure.Factory;
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
    public class DomainServicesContextConfiguration: StartupDomainServicesContextInstaller 
    {        
        public DomainServicesContextConfiguration(StartupServiceConfigurationInstaller _configureServicesInstaller)
            : base(_configureServicesInstaller)
        { }
        
        public override void InstallServices()
        {
            _configureServicesInstaller
                .GetServiceCollection()

                .AddScoped<IUserFactory, UserFactory>()
                .AddScoped<ITokenFactory, TokenFactory>()

                .AddScoped<UserSignUpEmailDoesNotExistValidator>()
                .AddScoped<UserSignUpCountryExistsValidator>()
                .AddScoped<UserFindByEmailAndPasswordValidator>()
                .AddScoped<UserFindByIdValidator>()
                .AddScoped<UserPartialUpdateUserValidator>()                
                .AddScoped<TokenCreateValidator>();

        }
    }
}
