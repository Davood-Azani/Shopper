using System;

namespace Shopper.Domain.Entities
{
    public class ProductCharacteristic : BaseEntity
    {
        public string CharacteristicName { get; set; } = default!;
        public string CharacteristicValue { get; set; } = default!;
        public string? CharacteristicDescription { get; set; }

        // for soft delete
        public bool IsDeleted { get; set; } = false;

        // Foreign key
        public int ProductTypeId { get; set; }

        // Navigation Property
        public ProductType ProductType { get; set; }
    }


}
