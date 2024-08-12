
using Shopper.Application.Product.Dtos;

namespace Shopper.Application.Common;

public class PagedResult<T>
{
    public PagedResult(IReadOnlyList<T> items, int totalsItemsCount , int pageSize , int pageNumber)
    {
        Items = items;
        TotalsItemsCount = totalsItemsCount;
        TotalPages = (int)Math.Ceiling(totalsItemsCount / (double)pageSize);
        ItemsFrom = pageSize * (pageNumber - 1) + 1;
        ItemsTo = ItemsFrom + pageSize - 1;

    }

    public IReadOnlyList<T> Items { get; set; }
    public int TotalPages { get; set; }

    public int TotalsItemsCount { get; set; }

    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }

}