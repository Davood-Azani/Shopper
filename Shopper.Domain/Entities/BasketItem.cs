namespace Shopper.Domain.Entities;

    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public string Type { get; set; } = default!;
    }
