using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Application.DTOs.Products.CreateProduct;
using ProductManagementSystem.Application.DTOs.Products.DeleteProduct;
using ProductManagementSystem.Application.DTOs.Products.GetProducts;
using ProductManagementSystem.Application.DTOs.Products.UpdateProduct;
using ProductManagementSystem.Application.Products.Commands.CreateProduct;
using ProductManagementSystem.Application.Products.Commands.DeleteProduct;
using ProductManagementSystem.Application.Products.Commands.UpdateProduct;
using ProductManagementSystem.Application.Products.Queries.GetProducts;

namespace ProductManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    /// <summary>لیست محصولات/summary>
    [HttpGet("[action]")]
    public async Task<GetProductsResponse> Products([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<GetProductsQuery>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<GetProductsResponse>();
        return response;
    }

    /// <summary>افزودن محصول/summary>
    [HttpPost]
    public async Task<CreateProductResponse> Create(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<CreateProductResponse>();
        return response;
    }

    /// <summary>ادیت محصول/summary>
    [HttpPut]
    public async Task<UpdateProductResponse> Update(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateProductCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<UpdateProductResponse>();
        return response;
    }

    /// <summary>حذف محصول</summary>
    [HttpDelete]
    public async Task<DeleteProductResponse> Delete(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<DeleteProductCommand>();
        var result = await mediator.Send(command, cancellationToken);
        var response = result.Adapt<DeleteProductResponse>();
        return response;
    }
}