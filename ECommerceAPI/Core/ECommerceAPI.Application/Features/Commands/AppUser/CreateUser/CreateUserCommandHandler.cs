using P = ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ECommerceAPI.Application.Exceptions;

namespace ECommerceAPI.Application.Features.Commands.AppUser.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly UserManager<P.AppUser> _userManager;

    public CreateUserCommandHandler(UserManager<P.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        IdentityResult result = await _userManager.CreateAsync(new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            SurName = request.SurName,
            Email = request.Email,
            UserName = request.UserName
        }, request.Password);
        if (result.Succeeded)
        {
            return new()
            {
                isSucceeded = true,
                Message = "User added successfully"
            };
        }
        else
            throw new UserCreateFailedException();
    }
}
