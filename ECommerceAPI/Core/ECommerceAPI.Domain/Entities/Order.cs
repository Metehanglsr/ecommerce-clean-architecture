using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = new Collection<Product>();
        public Customer Customer { get; set; } = default!;
    }
}
