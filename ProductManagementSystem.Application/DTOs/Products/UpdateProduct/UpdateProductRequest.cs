namespace ProductManagementSystem.Application.DTOs.Products.UpdateProduct;

public record UpdateProductRequest(string? Name, string? ManufactureEmail, DateTime ProduceDate, string? ManufacturePhone, bool IsAvailable);
