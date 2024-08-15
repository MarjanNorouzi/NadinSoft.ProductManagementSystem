using Microsoft.AspNetCore.Identity;
using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Application.Securities;
using ProductManagementSystem.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProductManagementSystem.Application.Users.Commands.Login;

public class LoginHandler
    (UserManager<ApplicationUser> userManager, ITokenService tokenService)
    : ICommandHandler<LoginCommand, LoginResult>
{
    public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(command.UserName!) ?? throw new Exception("User not found.");

        if (await userManager.CheckPasswordAsync(user, command.Password!))
        {
            return new LoginResult(tokenService.GenerateToken
            (
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim("UserId", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ));
        }

        return new LoginResult("");
    }
}
