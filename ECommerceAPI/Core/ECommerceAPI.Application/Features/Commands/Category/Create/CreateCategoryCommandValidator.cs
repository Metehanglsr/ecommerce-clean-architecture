using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Commands.Category.Create;


public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be null");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description cannot be null");
    }
}
