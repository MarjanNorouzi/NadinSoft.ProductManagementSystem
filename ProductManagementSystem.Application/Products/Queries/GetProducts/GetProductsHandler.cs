using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Products.Queries.GetProducts;

public class GetProductsHandler() : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}