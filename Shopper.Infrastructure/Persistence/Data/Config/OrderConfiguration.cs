using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopper.Domain.Entities.OrderAggregate;

namespace Shopper.Infrastructure.Persistence.Data.Config
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();
            });
            builder.Navigation(a => a.ShipToAddress).IsRequired();
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
             builder.Property(p => p.Subtotal).HasColumnType("decimal(18,2)");
        }
    }
}