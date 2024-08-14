using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}