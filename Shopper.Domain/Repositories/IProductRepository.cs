

using System.Collections.ObjectModel;
using Shopper.Domain.Constants;
using Shopper.Domain.Entities;

namespace Shopper.Domain.Repositories;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<(IReadOnlyCollection<Product>, int totalCount)> GetAllMatchingProductsAsync(string? searchPhrase,
        int pageNumber, int pageSize ,  string? sortBy, SortDirection sortDirection);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    Task<int> AddProductAsync(Product product);

    Task DeleteProductAsync(Product product);

    Task<int> GetProductCountByUserId(string id);
    Task SaveChangesAsync();
}