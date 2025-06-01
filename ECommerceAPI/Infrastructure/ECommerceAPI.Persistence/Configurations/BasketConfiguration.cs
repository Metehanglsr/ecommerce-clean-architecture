using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Configurations
{
    internal sealed class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasOne(b => b.Customer)
                   .WithOne(c => c.Basket)
                   .HasForeignKey<Basket>(b => b.CustomerId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}