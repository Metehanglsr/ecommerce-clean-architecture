using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories;

public sealed class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
{
    public AddressWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}