using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories
{
    public interface IInvoiceFileWriteRepository : IWriteRepository<P.InvoiceFile>
    {
    }
}