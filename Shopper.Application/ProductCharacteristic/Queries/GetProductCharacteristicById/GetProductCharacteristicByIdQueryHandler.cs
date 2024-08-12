

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Application.ProductCharacteristic.Dtos;
using Shopper.Domain.Exceptions;
using Shopper.Domain.Repositories;

namespace Shopper.Application.ProductCharacteristic.Queries.GetProductCharacteristicById;

public class GetProductCharacteristicByIdQueryHandler(ILogger<GetProductCharacteristicByIdQueryHandler> logger , 
    IMapper mapper , IProductCharacteristicRepository productCharacteristicRepository) : IRequestHandler<GetProductCharacteristicByIdQuery, ProductCharacteristicDto>
{
    public async Task<ProductCharacteristicDto> Handle(GetProductCharacteristicByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductCharacteristicByIdQueryHandler called with {id}" , request.Id);

        var productCharacteristic = await productCharacteristicRepository.GetProductCharacteristicByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(ProductCharacteristic) , request.Id.ToString());
        var productCharacteristicDto = mapper.Map<ProductCharacteristicDto>(productCharacteristic);
        return productCharacteristicDto;
    }
}

