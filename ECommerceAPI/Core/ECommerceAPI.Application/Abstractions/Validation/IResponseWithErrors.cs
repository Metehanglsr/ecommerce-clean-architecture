using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ECommerceAPI.Application.Abstractions.Validation;

public interface IResponseWithErrors
{
    void SetErrors(List<ValidationFailure> failures);
}
