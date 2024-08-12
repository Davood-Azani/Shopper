using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopper.Domain.Entities;
using Shopper.Domain.Entities.Identity;
using Shopper.Domain.Entities.OrderAggregate;

namespace Shopper.Infrastructure.Persistence;


public class StoreDbContext(DbContextOptions<StoreDbContext> options) : IdentityDbContext<User>(options)
{

    internal DbSet<Product> Products { get; set; }
    internal DbSet<ProductBrand> ProductBrands { get; set; }
    internal DbSet<ProductType> ProductTypes { get; set; }
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<OrderItem> OrderItems { get; set; }
    internal DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    internal DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}