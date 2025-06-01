using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Application.Repositories;

public interface IUnitOfWork
{
    IReadRepository<T> ReadRepository<T>() where T : BaseEntity;
    IWriteRepository<T> WriteRepository<T>() where T : BaseEntity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}