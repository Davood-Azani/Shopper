using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shopper.Application.ProductCharacteristic.Dtos;

namespace Shopper.Application.ProductCharacteristic.Queries
{
    public class GetAllProductCharacteristicsQuery:IRequest<IReadOnlyList<ProductCharacteristicDto>>
    {

    }
}
