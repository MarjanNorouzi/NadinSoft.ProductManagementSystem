using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Infrastructure.Products.Persistence;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasKey(p => new { p.ManufactureEmail, p.ProduceDate });

        builder
            .Property(p => p.Name)
            .HasMaxLength(100).IsRequired();

        builder
            .Property(p => p.ProduceDate)
            .IsRequired();

        builder
            .Property(p => p.ManufacturePhone)
            .IsFixedLength(true)
            .HasMaxLength(11)
            .IsRequired();

        builder
            .Property(p => p.ManufactureEmail)
            .HasMaxLength(320)
            .IsRequired();

        builder
            .Property(x => x.IsAvailable);

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}