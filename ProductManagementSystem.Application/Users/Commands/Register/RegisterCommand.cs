namespace ProductManagementSystem.Application.Users.Commands.Register;

public record RegisterCommand(string? UserName, string? Password, string? ConfirmPassword)
    : ICommand<RegisterResult>;

public record RegisterResult(bool IsSuccess);

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required.");
    }
}
