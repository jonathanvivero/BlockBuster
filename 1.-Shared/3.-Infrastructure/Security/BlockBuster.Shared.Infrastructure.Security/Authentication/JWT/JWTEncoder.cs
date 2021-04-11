using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Security.Authentication.JWT
{
    public class JWTEncoder : IJWTEncoder
    {
        private readonly IConfiguration configuration;

        public JWTEncoder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Encode(IDictionary<string, string> payload)
        {
            var secret = this.configuration.GetSection("AppSettings:Secret").Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, payload["user_id"]),
                    new Claim(ClaimTypes.Email, payload["email"]),
                    new Claim(ClaimTypes.Name, payload["first_name"]),
                    new Claim(ClaimTypes.Surname, payload["last_name"]),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
