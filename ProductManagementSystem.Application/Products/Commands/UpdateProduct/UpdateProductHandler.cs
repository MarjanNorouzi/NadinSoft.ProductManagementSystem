using Mapster;
using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository productRepository) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await productRepository.UpdateAsync(command.Adapt<Product>(), cancellationToken);

        return new UpdateProductResult(result);
    }
}