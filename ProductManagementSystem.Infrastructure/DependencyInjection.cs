using Microsoft.Extensions.Configuration;

namespace ProductManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services = services.AddDbContext<ProductManagementContext>(x => x.UseSqlServer(configuration.GetConnectionString("ProductManagementSystemDb")));
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
