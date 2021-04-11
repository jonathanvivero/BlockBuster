using BlockBuster.IAM.Application.Converters.Token;
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Application.UseCases.Country.Find;
using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.IAM.Domain.TokenAggregate.Factories;
using BlockBuster.IAM.Domain.TokenAggregate.Repository;
using BlockBuster.IAM.Domain.TokenAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Infrastructure.Factory;
using BlockBuster.IAM.Infrastructure.Presistence.Repositories;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.Middleware;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Startup
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
