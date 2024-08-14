using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ProductManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
