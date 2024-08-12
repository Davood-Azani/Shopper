
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Application.Common;
using Shopper.Application.Product.Dtos;
using Shopper.Domain.Repositories;

namespace Shopper.Application.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(ILogger<GetAllProductsQueryHandler> logger ,
    IProductRepository productRepository ,IMapper mapper): IRequestHandler<GetAllProductsQuery, PagedResult<ProductDto>>
{
    public async Task<PagedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetAllProductsQueryHandler called");
        var (products, totalCount) =
            await productRepository.GetAllMatchingProductsAsync(request.SearchPhrase , 
                request.PageNumber ,  request.PageSize , request.SortBy , request.SortDirection);
        var productDto = mapper.Map<IReadOnlyList<ProductDto>>(products);


        var result = new PagedResult<ProductDto>(productDto ,totalCount ,request.PageSize , request.PageNumber );

        return result;
    }
}