using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(string Name, string ManufactureEmail) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);
