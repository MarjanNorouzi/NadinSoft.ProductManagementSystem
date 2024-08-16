using Mapster;
using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Application.Securities;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository, IUserContext userContext) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Product>();
        product.UserId = userContext.Id;
        var result = await productRepository.AddAsync(product);

        return new CreateProductResult(result.ManufactureEmail, result.ProduceDate);
    }
}