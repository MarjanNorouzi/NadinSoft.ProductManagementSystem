namespace ProductManagementSystem.Application.DTOs.Users.Login;

public record LoginRequest(string UserName, string MD5Password);
