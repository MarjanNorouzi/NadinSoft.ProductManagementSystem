using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAllAsync(cancellationToken);

        return new GetProductsResult(result);
    }
}