using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using ProductManagementSystem.Domain.Models;
using ProductManagementSystem.Infrastructure.Contexts;

namespace ProductManagementSystem.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {

        services
            .AddIdentity<ApplicationUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<ProductManagementContext>()
            .AddDefaultTokenProviders();

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            foreach (string fileName in xmlFiles)
            {
                string xmlFilePath = Path.Combine(AppContext.BaseDirectory, fileName);
                if (File.Exists(xmlFilePath))
                    options.IncludeXmlComments(xmlFilePath, includeControllerXmlComments: true);
            };
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Ordering HTTP API",
                Version = "v1",
                Description = "The Ordering Service HTTP API",
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the bearer scheme",
                Name = "Authorization",
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
              {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
              }
            });
        });

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
