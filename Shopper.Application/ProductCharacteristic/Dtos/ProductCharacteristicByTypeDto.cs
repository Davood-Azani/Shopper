

namespace Shopper.Application.ProductCharacteristic.Dtos
{
    public class ProductCharacteristicByTypeDto
    {
        public int Id { get; set; }
        public string CharacteristicName { get; set; }
        public string CharacteristicValue { get; set; } 
        public string? CharacteristicDescription { get; set; }
    }
}
