using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string? Name, string? ManufactureEmail, DateTime ProduceDate, string? ManufacturePhone, bool IsAvailable) : ICommand<CreateProductResult>;

public record CreateProductResult(int Id);
