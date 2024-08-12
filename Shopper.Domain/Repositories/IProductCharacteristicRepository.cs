using Shopper.Domain.Entities;

namespace Shopper.Domain.Repositories;

public interface IProductCharacteristicRepository
{
    Task<int> AddProductCharacteristicAsync(ProductCharacteristic productCharacteristic);
    Task<ProductCharacteristic?> GetProductCharacteristicByIdAsync(int id);
    Task<IReadOnlyList<ProductCharacteristic>> GetAllProductCharacteristicsAsync();
    Task<IReadOnlyList<ProductCharacteristic>> GetProductCharacteristicsByTypeAsync(int typeId);
    Task DeleteProductCharacteristicAsync(ProductCharacteristic productCharacteristic);
    Task SaveChangesAsync();
}