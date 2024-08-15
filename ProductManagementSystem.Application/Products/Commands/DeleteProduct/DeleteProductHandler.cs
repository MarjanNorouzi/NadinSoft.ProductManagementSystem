using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}