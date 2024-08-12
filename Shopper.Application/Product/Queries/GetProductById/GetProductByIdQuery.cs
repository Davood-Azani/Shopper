using MediatR;
using Shopper.Application.Product.Dtos;

namespace Shopper.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQuery(int id):IRequest<ProductDto>
    {
        public int Id { get; set; } = id;
    }
}
