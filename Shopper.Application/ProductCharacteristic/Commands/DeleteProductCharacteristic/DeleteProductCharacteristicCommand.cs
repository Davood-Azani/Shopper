
using MediatR;

namespace Shopper.Application.ProductCharacteristic.Commands.DeleteProductCharacteristic
{
    public class DeleteProductCharacteristicCommand(int id) :IRequest
    {
        public int Id { get;  } = id;
    }
}
