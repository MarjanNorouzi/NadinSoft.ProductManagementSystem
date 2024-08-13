using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace ProductManagementSystem.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region " Cross - Cutting Services "

        #endregion
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}
