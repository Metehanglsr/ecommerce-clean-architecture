using ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser;

public class LoginUserCommandResponse
{
}

public sealed class LoginUserCommandSuccessResponse : LoginUserCommandResponse
{
    public TokenDto Token { get; set; } = default!;
}

public sealed class LoginUserCommandFailedResponse : LoginUserCommandResponse
{
    public string Message { get; set; } = string.Empty;
}
