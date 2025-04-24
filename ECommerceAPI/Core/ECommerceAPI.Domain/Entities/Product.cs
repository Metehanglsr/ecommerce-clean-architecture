using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
    }
}
