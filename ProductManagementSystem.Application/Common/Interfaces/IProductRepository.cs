using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Common.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);

    Task<Product?> GetByIdAsync(string manufactureEmail, DateTime produceDate);

    IAsyncEnumerable<Product> GetAllAsync(int? userId);

    Task<IEnumerable<Product>> GetAllAsync();

    void UpdateAsync(Product product);

    Task DeleteAsync(string manufactureEmail, DateTime produceDate);

    Task<int> SaveChangesAsync();
}