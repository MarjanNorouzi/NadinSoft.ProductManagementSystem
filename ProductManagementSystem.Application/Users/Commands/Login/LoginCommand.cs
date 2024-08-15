using FluentValidation;
using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Application.Products.Commands.CreateProduct;

namespace ProductManagementSystem.Application.Users.Commands.Login;

public record LoginCommand(string? UserName, string? MD5Password) : ICommand<LoginResult>;

public record LoginResult(int Id);

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");

        RuleFor(x => x.MD5Password).NotEmpty().WithMessage("Password is required.");
    }
}
