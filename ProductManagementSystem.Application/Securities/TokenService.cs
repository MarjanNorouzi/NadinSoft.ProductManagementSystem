using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementSystem.Application.Securities;

public class TokenService : ITokenService
{

    private const string UserIdClaimType = "UserId";

    private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
    private readonly SigningCredentials _signingCredentials;
    private readonly int _tokenLifeTime = 5;

    public TokenService(IConfiguration configuration)
    {
        _tokenLifeTime = Convert.ToInt32(configuration.GetSection("Jwt:LifeTimeInMinutes").ToString()!);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").ToString()!));
        _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public string GenerateToken(int userId, params Claim[] claims)
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
}

public interface ITokenService
{
    public string GenerateToken(int userId, params Claim[] claims);
}
