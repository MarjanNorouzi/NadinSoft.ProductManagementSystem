using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Common.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);

    Task<int> SaveChangesAsync();
}