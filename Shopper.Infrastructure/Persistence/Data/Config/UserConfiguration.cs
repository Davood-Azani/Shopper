using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopper.Domain.Entities.Identity;

namespace Shopper.Infrastructure.Persistence.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.OwnedProducts)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId);
    }
}