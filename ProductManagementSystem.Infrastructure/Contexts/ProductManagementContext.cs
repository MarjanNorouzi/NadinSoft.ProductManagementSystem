using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Domain.Models;
using ProductManagementSystem.Infrastructure.Products.Persistence;

namespace ProductManagementSystem.Infrastructure.Contexts
{
    public class ProductManagementContext(DbContextOptions<ProductManagementContext> option)
        : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(option)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);

            // TODO : In case of using UserRoles, remove Ignore Role lines
            modelBuilder.Ignore<IdentityUserClaim<int>>();
            modelBuilder.Ignore<IdentityRoleClaim<int>>();
            modelBuilder.Ignore<IdentityRole<int>>();
            modelBuilder.Ignore<IdentityUserRole<int>>();
        }
    }
}
