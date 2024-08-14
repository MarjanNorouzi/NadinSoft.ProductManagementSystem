using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Queries.GetProducts;

public class GetProductsHandler() : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public Task<GetProductsResult> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}