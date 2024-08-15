using FluentValidation;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string? Name, string? ManufactureEmail, DateTime ProduceDate, string? ManufacturePhone, bool IsAvailable) : ICommand<CreateProductResult>;

public record CreateProductResult(string? ManufactureEmail, DateTime? ProduceDate);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name max allowed length is 100 character");

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
        return (phoneNumber?.StartsWith('0') ?? false) && long.TryParse(phoneNumber, out var _);
    }
}