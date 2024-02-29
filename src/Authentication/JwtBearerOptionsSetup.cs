using ClimaTempoWebAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClimaTempoWebAPI.Authentication
{
    public class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;

            // Verifica se a chave JWT está vazia ou nula
            if (string.IsNullOrEmpty(_jwtOptions.SecretKey))
            {
                // Gera uma nova chave JWT aleatória com 64 caracteres
                _jwtOptions = new JwtOptions
                {
                    Issuer = _jwtOptions.Issuer,
                    Audience = _jwtOptions.Audience,
                    SecretKey = KeyGenerator.GenerateRandomKey(64)
                };
            }
        }

        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
            options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
            options.TokenValidationParameters.IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        }
    }
}
