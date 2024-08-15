using Microsoft.AspNetCore.Identity;
using ProductManagementSystem.Domain.Models;
using ProductManagementSystem.Infrastructure.Contexts;

namespace ProductManagementSystem.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region " Cross - Cutting Services "

        services
            .AddIdentity<ApplicationUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<ProductManagementContext>()
            .AddDefaultTokenProviders();

        #endregion

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
