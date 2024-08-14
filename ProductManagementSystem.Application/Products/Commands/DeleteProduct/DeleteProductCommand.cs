using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Product Product) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);
