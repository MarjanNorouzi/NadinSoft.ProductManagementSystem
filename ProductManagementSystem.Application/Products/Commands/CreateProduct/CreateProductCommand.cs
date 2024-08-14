using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(Product Product) : ICommand<CreateProductResult>;

public record CreateProductResult(int Id);
