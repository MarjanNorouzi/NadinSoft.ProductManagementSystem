using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Domain.Models;
using ProductManagementSystem.Infrastructure.Contexts;

namespace ProductManagementSystem.Infrastructure.Products.Persistence;

public class ProductRepository(ProductManagementContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product product) => await dbContext.AddAsync(product);

    public async Task<Product?> GetByIdAsync(string manufactureEmail, DateTime produceDate) => await dbContext.FindAsync<Product>(manufactureEmail, produceDate);

    public IAsyncEnumerable<Product> GetAllAsync(int? userId) => dbContext.Products.Where(p => p.UserId == userId || !userId.HasValue).AsAsyncEnumerable();

    public async Task<IEnumerable<Product>> GetAllAsync() => await dbContext.Products.ToListAsync();

    public void UpdateAsync(Product product) => dbContext.Update(product);
    //if (!await dbContext.Products.AnyAsync(p => p.ManufactureEmail == product.ManufactureEmail && p.ProduceDate == product.ProduceDate)) throw new Exception("Product not found.");

    public async Task DeleteAsync(string manufactureEmail, DateTime produceDate)
    {
        // TODO : شاید چک کردن وجود داشتن یا نداشتن انتیتی را در هندلر انجام دادم
        var product = await dbContext.FindAsync<Product>(manufactureEmail, produceDate) ?? throw new Exception("Product not found.");

        dbContext.Remove(product);
    }

    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
}