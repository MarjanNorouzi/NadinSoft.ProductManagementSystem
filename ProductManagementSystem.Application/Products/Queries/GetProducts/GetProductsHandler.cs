using ProductManagementSystem.Application.Common.Interfaces;

namespace ProductManagementSystem.Application.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAllAsync(query.CreatorId, cancellationToken);

        return new GetProductsResult(result);
    }
}