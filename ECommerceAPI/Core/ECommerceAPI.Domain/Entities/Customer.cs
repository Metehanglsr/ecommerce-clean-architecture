using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string SurName { get; set; } = default!;
        [NotMapped]
        public string FullName => string.Join(" ", Name, SurName);
        public ICollection<Order> Orders { get; set; } = new Collection<Order>();
    }
}
