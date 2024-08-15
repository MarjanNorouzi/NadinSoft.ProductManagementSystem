using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}