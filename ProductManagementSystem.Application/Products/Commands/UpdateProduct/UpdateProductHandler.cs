using Microsoft.AspNetCore.Http;
using ProductManagementSystem.Application.Common.Interfaces;

namespace ProductManagementSystem.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository productRepository, IUserContext userContext) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        // با این فرض که مقادیر یونیک 
        // ManufactureEmail و ProduceDate
        // ثابت و غیرقابل تغییر هستند
        var product = await productRepository.GetByIdAsync(command.ManufactureEmail!, command.ProduceDate, cancellationToken)
            ?? throw new Exceptions.ApplicationException("Product not found.", StatusCodes.Status404NotFound, false);

        if (userContext.Id != product.UserId) throw new Exceptions.ApplicationException("Just creator can edit product.", StatusCodes.Status401Unauthorized, false);

        var result = await productRepository.UpdateAsync(command.Adapt<Product>(), cancellationToken);

        return new UpdateProductResult(result);
    }
}