using Mapster;
using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // TODO : add user
        var result = await productRepository.AddAsync(command.Adapt<Product>(), cancellationToken);
        
        return new CreateProductResult(result.ManufactureEmail, result.ProduceDate);
    }
}