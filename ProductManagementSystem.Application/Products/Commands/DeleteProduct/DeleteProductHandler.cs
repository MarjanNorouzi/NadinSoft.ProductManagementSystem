using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public Task<DeleteProductResult> HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}