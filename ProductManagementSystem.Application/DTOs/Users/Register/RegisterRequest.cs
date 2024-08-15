namespace ProductManagementSystem.Application.DTOs.Users.Register;

public record RegisterRequest(string? UserName, string? Password, string? ConfirmPassword, string? FirstName, string? LastName);
