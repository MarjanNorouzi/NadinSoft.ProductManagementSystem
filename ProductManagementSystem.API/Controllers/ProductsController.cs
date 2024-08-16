using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.API.Filter;
using ProductManagementSystem.Application.DTOs.Products.CreateProduct;
using ProductManagementSystem.Application.DTOs.Products.DeleteProduct;
using ProductManagementSystem.Application.DTOs.Products.GetProducts;
using ProductManagementSystem.Application.DTOs.Products.UpdateProduct;
using ProductManagementSystem.Application.Products.Commands.CreateProduct;
using ProductManagementSystem.Application.Products.Commands.DeleteProduct;
using ProductManagementSystem.Application.Products.Commands.UpdateProduct;
using ProductManagementSystem.Application.Products.Queries.GetProducts;

namespace ProductManagementSystem.API.Controllers;

/// <summary>کنترلر محصولات</summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    /// <summary>لیست محصولات</summary>
    [AllowAnonymous]
    [HttpGet("[action]")]
    public async Task<IActionResult> Products([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<GetProductsQuery>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<GetProductsResponse>();
        return Ok(response);
    }

    /// <summary>افزودن محصول</summary>
    [CustomAuthorize(false, "User")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<CreateProductResponse>();
        return Ok(response);
    }

    /// <summary>ادیت محصول</summary>
    [CustomAuthorize(false, "User")]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateProductCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<UpdateProductResponse>();
        return Ok(response);
    }

    /// <summary>حذف محصول</summary>
    [CustomAuthorize(false, "User")]
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<DeleteProductCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<DeleteProductResponse>();
        return Ok(response);
    }
}