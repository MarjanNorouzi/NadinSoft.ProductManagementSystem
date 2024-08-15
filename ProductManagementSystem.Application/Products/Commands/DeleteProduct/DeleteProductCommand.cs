using FluentValidation;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(string Name, string ManufactureEmail) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);


public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.ManufactureEmail)
            .NotEmpty().WithMessage("ManufactureEmail is required.")
            .EmailAddress().WithMessage("ManufactureEmail is not valid.");
    }
}