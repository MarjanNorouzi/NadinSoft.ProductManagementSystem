using ProductManagementSystem.Application.Common.Interfaces;
using ProductManagementSystem.Domain.Models;
using ProductManagementSystem.Infrastructure.Contexts;

namespace ProductManagementSystem.Infrastructure.Products.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementContext _dbContext;

        public ProductRepository(ProductManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.AddAsync(product);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _dbContext.FindAsync<Product>(id);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}