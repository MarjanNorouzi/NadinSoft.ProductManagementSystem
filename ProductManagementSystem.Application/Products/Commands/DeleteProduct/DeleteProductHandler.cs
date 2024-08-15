using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var result = await productRepository.DeleteAsync(command.ManufactureEmail!, command.ProduceDate, cancellationToken);

        return new DeleteProductResult(result);
    }
}