using FluentValidation;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(string? ManufactureEmail, DateTime ProduceDate) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);


public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ManufactureEmail)
            .NotEmpty().WithMessage("ManufactureEmail is required.")
            .EmailAddress().WithMessage("ManufactureEmail is not valid.");
    }
}