using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductManagementSystem.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementSystem.Application.Securities;

public class TokenService : ITokenService
{
    private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
    private readonly SigningCredentials _signingCredentials;
    private readonly int _tokenLifeTime = 5;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration)
    {
        _tokenLifeTime = Convert.ToInt32(configuration["Jwt:LifeTimeInMinutes"]!);
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").ToString()!));
        _signingCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
    }

    public string GenerateToken(params Claim[] claims)
    {
        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            null,
            DateTime.Now.AddMinutes(_tokenLifeTime),
            _signingCredentials);

        return jwtSecurityTokenHandler.WriteToken(token);
    }

    public ClaimsPrincipal Validate(string token)
    {
        var parameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true, // Ensure the token hasn't expired
            IssuerSigningKey = _key,
            TokenDecryptionKey = _key,
            ClockSkew = TimeSpan.Zero // No tolerance for clock skew
        };

        if (jwtSecurityTokenHandler.CanReadToken(token))
        {
            return jwtSecurityTokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
        }

        return null;
    }
}
