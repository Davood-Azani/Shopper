

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopper.Domain.Entities;

namespace Shopper.Infrastructure.Persistence.Data.Config;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.HasMany(e => e.ProductCharacteristics)
            .WithOne(pc => pc.ProductType);




    }
}
