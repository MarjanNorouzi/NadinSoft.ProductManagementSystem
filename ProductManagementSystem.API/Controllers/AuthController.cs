using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Application.DTOs.Users.Login;
using ProductManagementSystem.Application.DTOs.Users.Register;
using ProductManagementSystem.Application.Users.Commands.Login;
using ProductManagementSystem.Application.Users.Commands.Register;

namespace ProductManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    /// <summary>لاگین</summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<LoginCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<LoginResponse>();
        return Ok(response);
    }

    /// <summary>ثبت نام</summary>
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<RegisterCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<RegisterResponse>();
        return Ok(response);
    }
}
