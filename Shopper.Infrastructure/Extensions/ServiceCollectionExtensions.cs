using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopper.Domain.Entities.Identity;
using Shopper.Domain.Repositories;
using Shopper.Infrastructure.Persistence;
using Shopper.Infrastructure.Repositories;
using Shopper.Infrastructure.Seeders;

namespace Shopper.Infrastructure.Extensions
{


    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services,
            IConfiguration config)
        {

            #region StoreDbContext
            services.AddDbContext<StoreDbContext>(option =>
               {
                   option.UseSqlServer(config.GetConnectionString("ShopperDbConnection")).
                       EnableSensitiveDataLogging();
               });
            services.AddScoped<IDataSeederContext, DataSeederContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCharacteristicRepository, ProductCharacteristicRepository>();
            #endregion

            #region IdentityDbContext
          

            services.AddIdentityApiEndpoints<User>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    // Set the cookie expiration time
                })
                .AddRoles<IdentityRole>() // to add roles to the identity system (claims)
                .AddEntityFrameworkStores<StoreDbContext>()
                ;

            #endregion


          

        }

    }
}
