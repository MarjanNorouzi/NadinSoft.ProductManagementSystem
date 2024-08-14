using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Product Product) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);
