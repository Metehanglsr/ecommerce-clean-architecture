using P = ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ECommerceAPI.Application.Exceptions;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    readonly UserManager<P.AppUser> _userManager;
    readonly SignInManager<P.AppUser> _signInManager;

    public LoginUserCommandHandler(SignInManager<P.AppUser> signInManager, UserManager<P.AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
        if(user is null)
            user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
        if(user is null)
        {
            throw new UserNotFoundException();
        }
        SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
        if(result.Succeeded)
        {

        }
        return new();
    }
}