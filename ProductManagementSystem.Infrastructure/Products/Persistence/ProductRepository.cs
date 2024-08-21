using Microsoft.AspNetCore.Http;

namespace ProductManagementSystem.Infrastructure.Products.Persistence;

public class ProductRepository(ProductManagementContext dbContext) : IProductRepository
{
    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default, bool saveNow = true)
    {
        await dbContext.AddAsync(product, cancellationToken);

        if (saveNow)
            await dbContext.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<Product?> GetByIdAsync(string manufactureEmail, DateTime produceDate, CancellationToken cancellationToken = default) => await dbContext.FindAsync<Product>([manufactureEmail, produceDate], cancellationToken);

    public IAsyncEnumerable<Product> GetAllAsync(int? userId) => dbContext.Products.Where(p => p.UserId == userId || !userId.HasValue).AsAsyncEnumerable();

    public async Task<IEnumerable<Product>> GetAllAsync(int? userId, CancellationToken cancellationToken = default) => await dbContext.Products.Include(x => x.User).Where(p => p.UserId == userId || !userId.HasValue).ToListAsync(cancellationToken);

    public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default, bool saveNow = true)
    {
        if (!await dbContext.Products.AnyAsync(p => p.ManufactureEmail == product.ManufactureEmail && p.ProduceDate == product.ProduceDate))
            throw new Application.Exceptions.ApplicationException("Product not found.", StatusCodes.Status404NotFound, false);

        dbContext.Update(product);
        if (saveNow)
        {
            var affectedRows = await dbContext.SaveChangesAsync(cancellationToken);
            return affectedRows > 0;
        }
        return true;
    }

    public async Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken = default, bool saveNow = true)
    {
        dbContext.Remove(product);

        if (saveNow)
        {
            var affectedRows = await dbContext.SaveChangesAsync(cancellationToken);
            return affectedRows > 0;
        }
        return true;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await dbContext.SaveChangesAsync(cancellationToken);
}