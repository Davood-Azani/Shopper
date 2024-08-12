

using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shopper.Domain.Constants;
using Shopper.Domain.Entities;
using Shopper.Domain.Repositories;
using Shopper.Infrastructure.Persistence;

namespace Shopper.Infrastructure.Repositories;

internal class ProductRepository(StoreDbContext dbContext) : IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var products = await dbContext.Products.AsNoTracking()
             .Include(p => p.ProductBrand)
             .Include(p => p.ProductType)
             .ToListAsync();
        return products;
    }

    public async Task<(IReadOnlyCollection<Product>, int totalCount)> GetAllMatchingProductsAsync(string? searchPhrase,
        int pageNumber, int pageSize, string? sortBy, SortDirection sortDirection)
    {
        var query = searchPhrase?.ToLower();

        var queryProducts = dbContext.Products.AsQueryable().AsNoTracking();
        //.Include(p => p.ProductBrand)
        //.Include(p => p.ProductType)

        //Filtering
        if (query != null)
        {
            queryProducts = queryProducts.Where(p => p.Name.ToLower().Contains(query)
                                                     || p.Description.ToLower().Contains(query));
        }

        var totalCount = await queryProducts.CountAsync();

        //Sorting

        if (sortBy != null)
        {

            var columnSelector = sortBy switch
            {
                nameof(Product.Name) => (Expression<Func<Product, object>>)(p => p.Name),
                nameof(Product.Price) => (Expression<Func<Product, object>>)(p => p.Price),

                _ => throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null)
            };


            queryProducts = sortDirection == SortDirection.Descending ?
                   queryProducts.OrderByDescending(columnSelector) :
                   queryProducts.OrderBy(columnSelector);

        }

        //Paging
        queryProducts = queryProducts.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);




        

        var products = await queryProducts.ToListAsync();


        return (products, totalCount);




    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        var product = dbContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddProductAsync(Product product)
    {
        #region reminder
        //if (product.ProductBrand.Id != 0)
        //{
        //    dbContext.Set<ProductBrand>().Attach(product.ProductBrand);
        //}
        //if (product.ProductType.Id != 0)
        //{
        //    dbContext.Set<ProductType>().Attach(product.ProductType);
        //} 
        #endregion
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task DeleteProductAsync(Product product)
    {
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();

    }

    public async Task<int> GetProductCountByUserId(string id)
    {
        return await dbContext.Products.CountAsync(p => p.OwnerId == id);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}