using P = ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Features.Commands.AppUser.LoginUser;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    readonly UserManager<P.AppUser> _userManager;
    readonly SignInManager<P.AppUser> _signInManager;
    readonly ITokenHandler _tokenHandler;

    public LoginUserCommandHandler(SignInManager<P.AppUser> signInManager, UserManager<P.AppUser> userManager, ITokenHandler tokenHandler)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
        if(user is null)
            user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
        if(user is null)
        {
            //throw new UserNotFoundException();
            return new LoginUserCommandFailedResponse
            {
                Message = "Username or password is incorrect."
            };
        }
        SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
        if (result.Succeeded)
        {
            TokenDto token = _tokenHandler.CreateAccessToken(5);
            return new LoginUserCommandSuccessResponse()
            {
                Token = token
            };
        }
        else
            return new LoginUserCommandFailedResponse
            {
                Message = "Username or password is incorrect."
            };

    }
}