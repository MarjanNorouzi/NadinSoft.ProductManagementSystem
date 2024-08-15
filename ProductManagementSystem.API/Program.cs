using ProductManagementSystem.API;
using ProductManagementSystem.Application;
using ProductManagementSystem.Infrastructure;
using ProductManagementSystem.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    app.InitializeDatabaseAsync();
}

app.Run();