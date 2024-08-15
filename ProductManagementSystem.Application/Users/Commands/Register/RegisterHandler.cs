using Microsoft.AspNetCore.Identity;
using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Users.Commands.Register;

public class RegisterHandler
    (IPasswordHasher<ApplicationUser> passwordHasher,
    UserManager<ApplicationUser> userManager)
    : ICommandHandler<RegisterCommand, RegisterResult>
{
    public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser(command.UserName!);
        user.PasswordHash = passwordHasher.HashPassword(user, command.Password!);
        var result = await userManager.CreateAsync(user);

        return new RegisterResult(result.Succeeded);
    }
}
