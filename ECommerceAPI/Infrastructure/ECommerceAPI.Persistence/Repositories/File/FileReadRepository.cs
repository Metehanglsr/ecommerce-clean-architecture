using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using P = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Persistence.Repositories;

public sealed class FileReadRepository : ReadRepository<P.File>, IFileReadRepository
{
    public FileReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}