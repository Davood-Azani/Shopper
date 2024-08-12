

using Microsoft.EntityFrameworkCore;
using Shopper.Domain.Entities;
using Shopper.Domain.Repositories;
using Shopper.Infrastructure.Persistence;

namespace Shopper.Infrastructure.Repositories
{
    internal class ProductCharacteristicRepository(StoreDbContext dbContext) : IProductCharacteristicRepository
    {

        public async Task<int> AddProductCharacteristicAsync(ProductCharacteristic productCharacteristic)
        {
            dbContext.ProductCharacteristics.Add(productCharacteristic);
            await dbContext.SaveChangesAsync();
            return productCharacteristic.Id;
        }

        public async Task<ProductCharacteristic?> GetProductCharacteristicByIdAsync(int id)
        {
            var productCharacteristic = await dbContext.ProductCharacteristics
                .Include(a=>a.ProductType)
                .SingleOrDefaultAsync(a=>a.Id==id);
            return productCharacteristic;
        }


        public async Task<IReadOnlyList<ProductCharacteristic>> GetAllProductCharacteristicsAsync()
        {
            var productCharacteristics = await dbContext.ProductCharacteristics.AsNoTracking()
                .Include(a=>a.ProductType)
                .ToListAsync();
            return productCharacteristics;
        }

        public async Task<IReadOnlyList<ProductCharacteristic>> GetProductCharacteristicsByTypeAsync(int typeId)
        {
            var productCharacteristics = await dbContext.ProductCharacteristics.AsNoTracking()
                .Where(a => a.ProductTypeId==typeId)
                .ToListAsync();
            return productCharacteristics ;
            
        }

        public async Task DeleteProductCharacteristicAsync(ProductCharacteristic productCharacteristic)
        {
            
            dbContext.ProductCharacteristics.Remove(productCharacteristic);
            await dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }


    }
}
