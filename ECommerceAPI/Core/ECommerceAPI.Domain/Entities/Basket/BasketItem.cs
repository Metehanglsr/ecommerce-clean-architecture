using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public sealed class BasketItem : BaseEntity
{
    public int Quantity { get; set; }
    public Guid BasketId { get; set; }
    public Basket Basket { get; set; } = default!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
}