using ECommerceAPI.Application.Abstractions.Validation;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceAPI.Application.Features.Commands.Category.Create;

public sealed class CreateCategoryCommandResponse : IResponseWithErrors
{
    public List<string>? Errors { get; set; }

    public void SetErrors(List<ValidationFailure> failures)
    {
        Errors = failures.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToList();
    }
}
