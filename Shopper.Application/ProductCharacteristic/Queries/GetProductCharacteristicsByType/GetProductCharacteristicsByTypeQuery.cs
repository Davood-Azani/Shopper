
using MediatR;
using Shopper.Application.ProductCharacteristic.Dtos;

namespace Shopper.Application.ProductCharacteristic.Queries.GetProductCharacteristicsByType;

public class GetProductCharacteristicsByTypeQuery(int id):  IRequest<IReadOnlyList<ProductCharacteristicByTypeDto>>
{
    public int Id { get;  } = id;

}