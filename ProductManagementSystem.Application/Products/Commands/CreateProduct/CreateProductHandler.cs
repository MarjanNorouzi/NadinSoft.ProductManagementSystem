using ProductManagementSystem.Application.Common.Interfaces;

namespace ProductManagementSystem.Application.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository, IUserContext userContext) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Product>();
        product.UserId = userContext.Id;
        var result = (await productRepository.AddAsync(product)) ?? new Product();

        return new CreateProductResult(result.ManufactureEmail, result.ProduceDate);
    }
}