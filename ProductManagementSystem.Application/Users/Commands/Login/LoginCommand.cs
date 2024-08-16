namespace ProductManagementSystem.Application.Users.Commands.Login;

public record LoginCommand(string? UserName, string? Password) : ICommand<LoginResult>;

public record LoginResult(string Token);

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
    }
}
