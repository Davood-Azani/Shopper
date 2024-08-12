using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Application.Product.Dtos;
using Shopper.Domain.Exceptions;
using Shopper.Domain.Repositories;

namespace Shopper.Application.Product.Queries.GetProductById
{
    public class GetProductQueryHandler(ILogger<GetProductQueryHandler> logger , 
        IMapper mapper,IProductRepository productRepository):IRequestHandler<GetProductByIdQuery,ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductQueryHandler called with {id}" , request.Id);

            var product = await productRepository.GetProductByIdAsync(request.Id) ?? 
            throw new NotFoundException(nameof(Product) , request.Id.ToString());
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
