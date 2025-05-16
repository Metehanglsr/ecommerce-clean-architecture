using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public sealed class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public long Price { get; set; }
        public int Stock { get; set; }
    }
}