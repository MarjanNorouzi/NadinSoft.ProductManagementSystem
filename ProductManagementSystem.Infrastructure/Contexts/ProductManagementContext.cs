using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using ProductManagementSystem.Infrastructure.Configurations;

namespace ProductManagementSystem.Infrastructure.Contexts
{
    public class ProductManagementContext(DbContextOptions<ProductManagementContext> option)
        : DbContext(option)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
