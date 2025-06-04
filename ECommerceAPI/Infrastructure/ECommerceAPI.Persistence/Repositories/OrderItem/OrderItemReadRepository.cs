using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories;

public sealed class OrderItemReadRepository : ReadRepository<OrderItem>, IOrderItemReadRepository
{
    public OrderItemReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}