using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public long Price { get; set; }
        public int Stock { get; set; }
        public ICollection<Order> Orders { get; set; } = new Collection<Order>();
    }
}