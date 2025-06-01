using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceAPIDbContext _context;

        public UnitOfWork(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public IReadRepository<T> ReadRepository<T>() where T : BaseEntity
            => new ReadRepository<T>(_context);

        public IWriteRepository<T> WriteRepository<T>() where T : BaseEntity
            => new WriteRepository<T>(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}