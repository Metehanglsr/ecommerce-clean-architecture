using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Category.Create;

public sealed class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}