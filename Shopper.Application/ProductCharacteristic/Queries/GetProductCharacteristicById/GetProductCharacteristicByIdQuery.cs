

using MediatR;
using Shopper.Application.ProductCharacteristic.Dtos;

namespace Shopper.Application.ProductCharacteristic.Queries.GetProductCharacteristicById;

public class GetProductCharacteristicByIdQuery(int id) : IRequest<ProductCharacteristicDto>
{
    public int Id { get; set; } = id;

  
}
