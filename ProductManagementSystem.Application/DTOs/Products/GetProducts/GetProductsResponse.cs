namespace ProductManagementSystem.Application.DTOs.Products.GetProducts;

public record GetProductsResponse(IEnumerable<ProductItem> Products);

public record ProductItem(string Name, string ManufactureEmail, DateTime ProduceDate, string ManufacturePhone, bool IsAvailable, int UserId, string CreatorName);
