namespace ProductManagementSystem.Application.DTOs.Products.CreateProduct;

public record CreateProductRequest(string? Name, string? ManufactureEmail, DateTime ProduceDate, string? ManufacturePhone, bool IsAvailable);
