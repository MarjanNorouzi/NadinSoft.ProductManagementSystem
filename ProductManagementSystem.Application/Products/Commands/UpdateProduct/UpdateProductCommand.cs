using FluentValidation;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(string? Name, string? ManufactureEmail, DateTime ProduceDate, string? ManufacturePhone, bool IsAvailable) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.ManufactureEmail)
            .NotEmpty().WithMessage("ManufactureEmail is required.")
            .EmailAddress().WithMessage("ManufactureEmail is not valid.");

        RuleFor(x => x.ManufacturePhone)
            .NotEmpty().WithMessage("ManufacturePhone is required")
            .Must(IsValidPhoneNumberFormat)
            .Length(11, 11).WithMessage("ManufacturePhone must be exactly 11 digits long.");
    }
    private bool IsValidPhoneNumberFormat(string? phoneNumber)
    {
        // Example: Check if the phone number starts with '01'
        return (phoneNumber?.StartsWith('0') ?? false) && int.TryParse(phoneNumber, out var _);
    }
}