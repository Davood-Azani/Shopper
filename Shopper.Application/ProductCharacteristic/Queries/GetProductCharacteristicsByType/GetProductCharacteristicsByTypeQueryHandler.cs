

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Application.ProductCharacteristic.Dtos;
using Shopper.Domain.Repositories;

namespace Shopper.Application.ProductCharacteristic.Queries.GetProductCharacteristicsByType
{
    public  class GetProductCharacteristicsByTypeQueryHandler(IMapper mapper , ILogger<GetProductCharacteristicsByTypeQueryHandler> logger , 
        
        IProductCharacteristicRepository productCharacteristicRepository
        ) : IRequestHandler<GetProductCharacteristicsByTypeQuery, IReadOnlyList<ProductCharacteristicByTypeDto>>
    {
        public async Task<IReadOnlyList<ProductCharacteristicByTypeDto>> Handle(GetProductCharacteristicsByTypeQuery request, CancellationToken cancellationToken)
        {
           logger.LogInformation("GetProductCharacteristicsByTypeQueryHandler with typeId {id} called" , request.Id);
           var productCharacteristics = await productCharacteristicRepository.GetProductCharacteristicsByTypeAsync(request.Id);
           return mapper.Map<IReadOnlyList<ProductCharacteristicByTypeDto>>(productCharacteristics);
            
        }
    }
}
