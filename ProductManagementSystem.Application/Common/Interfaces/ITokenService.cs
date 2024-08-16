using System.Security.Claims;

namespace ProductManagementSystem.Application.Common.Interfaces;

public interface ITokenService
{
    public string GenerateToken(params Claim[] claims);

    public ClaimsPrincipal Validate(string token);
}
