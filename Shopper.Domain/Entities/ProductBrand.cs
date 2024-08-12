using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Domain.Entities
{
    public class ProductBrand:BaseEntity
    {
        public string Name { get; set; } = default!;
    }
}
