namespace ECommerceAPI.Application.Features.Commands.AppUser.CreateUser;

public sealed class CreateUserCommandResponse
{
    public string Message { get; set; } = string.Empty;
    public bool isSucceeded { get; set; }
}