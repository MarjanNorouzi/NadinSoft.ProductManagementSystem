using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Common.Interfaces;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default, bool saveNow = true);

    Task<Product?> GetByIdAsync(string manufactureEmail, DateTime produceDate, CancellationToken cancellationToken = default);

    IAsyncEnumerable<Product> GetAllAsync(int? userId);

    Task<IEnumerable<Product>> GetAllAsync(int? userId, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default, bool saveNow = true);

    Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken = default, bool saveNow = true);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}