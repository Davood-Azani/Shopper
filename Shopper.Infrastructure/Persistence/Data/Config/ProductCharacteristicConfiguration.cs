

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopper.Domain.Entities;

namespace Shopper.Infrastructure.Persistence.Data.Config;

public  class ProductCharacteristicConfiguration : IEntityTypeConfiguration<ProductCharacteristic>
{
    public void Configure(EntityTypeBuilder<ProductCharacteristic> builder)
    {
    
      
        builder.Property(e => e.CharacteristicName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.CharacteristicValue).IsRequired().HasMaxLength(50);
        builder.Property(e => e.CharacteristicDescription).HasMaxLength(100);

        builder.HasOne(e => e.ProductType)
            .WithMany(pt => pt.ProductCharacteristics)
            .HasForeignKey(e => e.ProductTypeId)
          
            ;


    }
}
