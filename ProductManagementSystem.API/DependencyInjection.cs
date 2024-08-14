using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Infrastructure.Contexts;

namespace ProductManagementSystem.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region " Cross - Cutting Services "

        services.AddDbContext<ProductManagementContext>(x => x.UseSqlServer(configuration.GetConnectionString("ProductManagementSystemDb")));

        #endregion

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
