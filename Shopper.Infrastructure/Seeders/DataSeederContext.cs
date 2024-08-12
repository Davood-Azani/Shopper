using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Constants;
using Shopper.Domain.Entities;
using Shopper.Domain.Entities.Identity;
using Shopper.Domain.Entities.OrderAggregate;
using Shopper.Infrastructure.Persistence;

namespace Shopper.Infrastructure.Seeders;

public interface IDataSeederContext
{
    Task SeedAsync();

}

internal class DataSeederContext(StoreDbContext dbContext, ILogger<DataSeederContext> logger,
        UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    : IDataSeederContext
{

    public async Task SeedAsync()

    {
        try
        {
            await dbContext.Database.MigrateAsync();
            if (await dbContext.Database.CanConnectAsync())
            {

                if (!await userManager.Users.AnyAsync())
                {
                    await SeedProductBrands();
                    await SeedProductTypes();
                    await SeedRoles();
                    await SeedUsers();
                    await SeedProducts();
                    await SeedDeliveryMethods();
                }

                if (dbContext.ChangeTracker.HasChanges()) await dbContext.SaveChangesAsync();
            }
            else
            {
                logger.LogError("An error occurred during Connecting to Database");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during migration");
        }
    }

    private async Task SeedProductBrands()
    {
        if (!await dbContext.ProductBrands.AnyAsync())
        {
            var brandsData = await File.ReadAllTextAsync("../Shopper.Infrastructure/Seeders/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if (brands != null) dbContext.ProductBrands.AddRange(brands);
        }
    }

    private async Task SeedProductTypes()
    {
        if (!await dbContext.ProductTypes.AnyAsync())
        {
            var typesData = await File.ReadAllTextAsync("../Shopper.Infrastructure/Seeders/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if (types != null) dbContext.ProductTypes.AddRange(types);
        }
    }

    private async Task SeedRoles()
    {
        if (!await dbContext.Roles.AnyAsync())
        {
            IReadOnlyList<IdentityRole> rolesList = new List<IdentityRole>
            {
                new (UserRoles.Admin){NormalizedName = UserRoles.Admin.ToUpper()},
                new (UserRoles.Owner){NormalizedName = UserRoles.Owner.ToUpper()},
                new (UserRoles.User){NormalizedName = UserRoles.User.ToUpper()}
            };
            dbContext.Roles.AddRange(rolesList);
        }
    }

    private async Task SeedUsers()
    {
        var adminUser = new User
        {
            Email = "admin@test.com",
            UserName = "admin@test.com"
        }; var testUser = new User
        {
            Email = "test@test.com",
            UserName = "test@test.com"
        };

        var result = await userManager.CreateAsync(adminUser, "Password1!");

        if (result.Succeeded)
        {
            await userManager.CreateAsync(testUser, "Password1!");
            var adminRole = await roleManager.FindByNameAsync(UserRoles.Admin);
            var userRole = await roleManager.FindByNameAsync(UserRoles.User);
            if (adminRole != null)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole.Name!);
            }
            if (userRole != null)
            {
                await userManager.AddToRoleAsync(testUser, userRole.Name!);
            }
        }
        else
        {
            foreach (var error in result.Errors)
            {
                logger.LogError("Error creating admin user: {Error}", error.Description);
            }
        }
    }

    private async Task SeedProducts()
    {
        if (!await dbContext.Products.AnyAsync())
        {
            var productsData = await File.ReadAllTextAsync("../Shopper.Infrastructure/Seeders/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            var adminUser = await userManager.FindByEmailAsync("admin@test.com");
            if (adminUser != null)
            {
                foreach (var item in products)
                {
                    item.OwnerId = adminUser.Id;
                }
                if (products != null) dbContext.Products.AddRange(products);
            }
        }
    }

    private async Task SeedDeliveryMethods()
    {
        if (!await dbContext.DeliveryMethods.AnyAsync())
        {
            var deliveryData = await File.ReadAllTextAsync("../Shopper.Infrastructure/Seeders/SeedData/delivery.json");
            var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
            if (methods != null) dbContext.DeliveryMethods.AddRange(methods);
        }
    }
}






