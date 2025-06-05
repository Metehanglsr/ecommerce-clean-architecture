using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Exceptions;

public sealed class UserCreateFailedException : Exception
{
    public UserCreateFailedException() : base("An error occurred while adding the user.")
    {
    }

    public UserCreateFailedException(string? message) : base(message)
    {
    }

    public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
