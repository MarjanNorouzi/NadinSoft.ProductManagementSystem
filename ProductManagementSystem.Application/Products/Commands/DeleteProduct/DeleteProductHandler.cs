﻿using Microsoft.AspNetCore.Http;
using ProductManagementSystem.Application.Common.Interfaces;

namespace ProductManagementSystem.Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler(IProductRepository productRepository, IUserContext userContext) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(command.ManufactureEmail!, command.ProduceDate, cancellationToken)
           ?? throw new Exceptions.ApplicationException("Product not found.", StatusCodes.Status404NotFound, false);

        if (userContext.Id != product.UserId) throw new Exceptions.ApplicationException("Just creator can edit product.", StatusCodes.Status401Unauthorized, false);

        var result = await productRepository.DeleteAsync(product, cancellationToken);

        return new DeleteProductResult(result);
    }
}