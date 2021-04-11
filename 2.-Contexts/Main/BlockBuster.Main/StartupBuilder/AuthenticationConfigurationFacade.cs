using BlockBuster.Shared.Infrastructure.Resources;
using BlockBuster.Shared.UI.ContextStartup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.Main.StartupBuilder
{
    public class AuthenticationConfigurationFacade
    {
        private readonly StartupServiceConfigurationInstaller _configureServiceInstaller;        

        public AuthenticationConfigurationFacade(StartupServiceConfigurationInstaller configureServiceInstaller)
        {
            _configureServiceInstaller = configureServiceInstaller;            
        }

        public void ConfigureAuthenticationServices()
        {
            var configuration = _configureServiceInstaller.GetConfiguration();
            var serviceCollection = _configureServiceInstaller.GetServiceCollection();

            var appSettingsSection = configuration.GetSection(ConfigurationEntryResources.SectionAppSettings);

            var secret = configuration.GetValue<string>(ConfigurationEntryResources.ValueAppSetings);
            var key = Encoding.ASCII.GetBytes(secret);

            serviceCollection
                .AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}
