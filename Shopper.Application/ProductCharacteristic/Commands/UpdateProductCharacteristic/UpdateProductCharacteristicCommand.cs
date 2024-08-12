

using MediatR;

namespace Shopper.Application.ProductCharacteristic.Commands.UpdateProductCharacteristic;

public class UpdateProductCharacteristicCommand : IRequest
{
    public int Id { get; set; }
    public string CharacteristicName { get; set; } = default!;
    public string CharacteristicValue { get; set; } = default!;
    public string? CharacteristicDescription { get; set; }
    public int ProductTypeId { get; set; }
}