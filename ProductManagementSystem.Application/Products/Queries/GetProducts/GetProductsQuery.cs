namespace ProductManagementSystem.Application.Products.Queries.GetProducts;

// TODO : if needed, implement pagination
public record GetProductsQuery(int? CreatorId) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);
