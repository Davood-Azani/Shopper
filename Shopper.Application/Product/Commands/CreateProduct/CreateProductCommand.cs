

using MediatR;

namespace Shopper.Application.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
  

   
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = default!;
    public int ProductTypeId { get; set; }
    public int ProductBrandId { get; set; }

    
    
}
