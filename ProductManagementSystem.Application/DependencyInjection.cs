using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Application.Behaviors;
using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Application.Extensions;
using ProductManagementSystem.Application.Securities;
using System.Reflection;

namespace ProductManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services = services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.RegisterMapsterConfiguration();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserContext, UserContext>();

        return services;
    }
}
