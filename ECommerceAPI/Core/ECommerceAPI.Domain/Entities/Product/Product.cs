using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public sealed class Product : BaseEntity
{
    public string Name { get; set; } = default!;
    public long Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public ICollection<BasketItem> BasketItems { get; set; } = new Collection<BasketItem>();
    public ICollection<OrderItem> OrderItems { get; set; } = new Collection<OrderItem>();
}