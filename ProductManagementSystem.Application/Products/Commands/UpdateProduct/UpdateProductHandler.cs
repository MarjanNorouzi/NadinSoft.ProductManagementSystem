using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public Task<UpdateProductResult> HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}