using Shopper.Domain.Entities;

namespace Shopper.Application.ProductCharacteristic.Dtos;

public class ProductCharacteristicDto
{
    public string CharacteristicName { get; set; } 
    public string CharacteristicValue { get; set; } 
    public string? CharacteristicDescription { get; set; }

    public int ProductTypeId { get; set; }
    
}