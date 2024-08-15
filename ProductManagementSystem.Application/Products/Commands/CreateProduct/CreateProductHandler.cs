using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var aa = productRepository;
        throw new NotImplementedException();
    }
}