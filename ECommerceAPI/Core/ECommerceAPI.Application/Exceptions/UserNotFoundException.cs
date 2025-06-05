using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Username or email is incorrect.")
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }
    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
