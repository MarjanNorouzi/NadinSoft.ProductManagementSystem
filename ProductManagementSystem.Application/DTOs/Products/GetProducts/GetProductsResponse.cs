namespace ProductManagementSystem.Application.DTOs.Products.GetProducts;

public record GetProductsResponse(string Name, string ManufactureEmail, DateTime ProduceDate, string ManufacturePhone, bool IsAvailable, int UserId, string CreatorName);
