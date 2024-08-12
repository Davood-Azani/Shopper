

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Exceptions;
using Shopper.Domain.Repositories;

namespace Shopper.Application.ProductCharacteristic.Commands.DeleteProductCharacteristic;

public class DeleteProductCharacteristicCommandHandler(ILogger<DeleteProductCharacteristicCommandHandler> logger , IMapper mapper,IProductCharacteristicRepository characteristicRepository) :IRequestHandler<DeleteProductCharacteristicCommand>
{
    public async Task Handle(DeleteProductCharacteristicCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCharacteristicCommandHandler called with id: {Id}", request.Id);
        var characteristic = await characteristicRepository.GetProductCharacteristicByIdAsync(request.Id)
         ?? throw new NotFoundException(nameof(ProductCharacteristic) , request.Id.ToString());

        await  characteristicRepository.DeleteProductCharacteristicAsync(characteristic);
    }
}
