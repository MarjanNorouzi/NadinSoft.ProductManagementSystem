using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProductManagementSystem.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static void InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ProductManagementContext>();

        if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
        {
            context.Database.EnsureCreated();
        }
    }
}
