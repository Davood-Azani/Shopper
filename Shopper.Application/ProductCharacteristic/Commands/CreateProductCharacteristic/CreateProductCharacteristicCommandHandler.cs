

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Repositories;

namespace Shopper.Application.ProductCharacteristic.Commands.CreateProductCharacteristic;

public class CreateProductCharacteristicCommandHandler(ILogger<CreateProductCharacteristicCommandHandler> logger ,
    
    IMapper mapper ,IProductCharacteristicRepository productCharacteristic):IRequestHandler<CreateProductCharacteristicCommand,int>
   
{
    public async Task<int> Handle(CreateProductCharacteristicCommand request, CancellationToken cancellationToken)
    {
       logger.LogInformation("CreateProductCharacteristicCommandHandler called  with  {@productCharacteristic}" , request);


       var productCharacteristicEntity = mapper.Map<Domain.Entities.ProductCharacteristic>(request);
      return await productCharacteristic.AddProductCharacteristicAsync(productCharacteristicEntity);
    }
}