

using MediatR;
using Shopper.Application.Common;
using Shopper.Application.Product.Dtos;
using Shopper.Domain.Constants;

namespace Shopper.Application.Product.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<PagedResult<ProductDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }

    public SortDirection SortDirection { get; set; } = SortDirection.Descending;





}