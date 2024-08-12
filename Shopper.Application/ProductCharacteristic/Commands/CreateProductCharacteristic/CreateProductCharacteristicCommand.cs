
using MediatR;

namespace Shopper.Application.ProductCharacteristic.Commands.CreateProductCharacteristic;

public class CreateProductCharacteristicCommand:IRequest<int>
{

    public string CharacteristicName { get; set; } = default!;
    public string CharacteristicValue { get; set; } = default!;
    public string? CharacteristicDescription { get; set; }
    public int ProductTypeId { get; set; }



}