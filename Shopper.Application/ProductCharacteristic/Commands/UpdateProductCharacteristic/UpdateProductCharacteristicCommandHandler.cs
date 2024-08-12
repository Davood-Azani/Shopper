
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Exceptions;
using Shopper.Domain.Repositories;

namespace Shopper.Application.ProductCharacteristic.Commands.UpdateProductCharacteristic;

public class UpdateProductCharacteristicCommandHandler(ILogger<UpdateProductCharacteristicCommandHandler> logger ,
    IMapper mapper , IProductCharacteristicRepository characteristicRepository) :IRequestHandler<UpdateProductCharacteristicCommand>

    {
    public  async Task Handle(UpdateProductCharacteristicCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCharacteristicCommandHandler called with id: {Id} with {@UpdateProductCharacteristic}", request.Id, request);
        var productCharacteristic = await characteristicRepository.GetProductCharacteristicByIdAsync(request.Id)
        ?? throw new NotFoundException(nameof(ProductCharacteristic) , request.Id.ToString());
        mapper.Map(request, productCharacteristic);
        await characteristicRepository.SaveChangesAsync();
        
    }
}