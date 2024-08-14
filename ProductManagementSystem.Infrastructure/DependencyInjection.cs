using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Infrastructure.Contexts;

namespace ProductManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services = services.AddDbContext<ProductManagementContext>(x => x.UseSqlServer(configuration.GetConnectionString("ProductManagementSystemDb")));
        return services;
    }
}
