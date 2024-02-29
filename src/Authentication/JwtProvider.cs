using ClimaTempoWebAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClimaTempoWebAPI.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        // Obtém o valor das opções JWT
        JwtOptions jwtOptions = options.Value;

        // Verifica se a chave JWT está vazia
        if (string.IsNullOrEmpty(jwtOptions.SecretKey))
        {
            // Gera uma nova chave JWT aleatória com 64 caracteres
            string secretKey = KeyGenerator.GenerateRandomKey(64);

            // Cria um novo objeto JwtOptions com a chave gerada
            jwtOptions = new JwtOptions
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                SecretKey = secretKey
            };
        }

        // Atribui as opções JWT ao campo _options
        _options = jwtOptions;
    }

    public string Generate(Guid userUuid, string email)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, userUuid.ToString()),
            new(JwtRegisteredClaimNames.Email, email)
        };


        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}