using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Application.ProductCharacteristic.Dtos;
using Shopper.Domain.Repositories;

namespace Shopper.Application.ProductCharacteristic.Queries
{
    public class GetAllProductCharacteristicsQueryHandler(ILogger<GetAllProductCharacteristicsQueryHandler> logger 
        ,IMapper mapper , IProductCharacteristicRepository productCharacteristic) : IRequestHandler<GetAllProductCharacteristicsQuery, IReadOnlyList<ProductCharacteristicDto>>
    {
        public async Task<IReadOnlyList<ProductCharacteristicDto>> Handle(GetAllProductCharacteristicsQuery request, CancellationToken cancellationToken)
        {
           logger.LogInformation("GetAllProductCharacteristicsQueryHandler called");
           var productCharacteristics = await productCharacteristic.GetAllProductCharacteristicsAsync();
           var result = mapper.Map<IReadOnlyList<ProductCharacteristicDto>>(productCharacteristics);
            return result;
            

        }
    }
}
