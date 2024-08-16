using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Application.DTOs.Products.GetProducts;
using ProductManagementSystem.Domain.Models;
using System.Reflection;

namespace ProductManagementSystem.Application.Extensions;

public static class MapsterConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<Product, ProductItem>
           .NewConfig()
           .Map(dest => dest.CreatorUserName, src => src.User.UserName);

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}