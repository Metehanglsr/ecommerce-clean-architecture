using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using P = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Persistence.Repositories;

public sealed class FileWriteRepository : WriteRepository<P.File>, IFileWriteRepository
{
    public FileWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}
