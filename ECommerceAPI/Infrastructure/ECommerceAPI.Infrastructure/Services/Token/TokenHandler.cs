using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Infrastructure.Services.Token;

public sealed class TokenHandler : ITokenHandler
{
    readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenDto CreateAccessToken(int minute)
    {
        TokenDto token = new();
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]!));
        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);
        token.ExpirationTime = DateTime.Now.AddMinutes(minute);
        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"]!,
            issuer: _configuration["Token:Issuer"]!,
            expires: token.ExpirationTime,
            notBefore: DateTime.Now,
            signingCredentials : signingCredentials
        );
        JwtSecurityTokenHandler securityTokenHandler = new();
        token.AccessToken = securityTokenHandler.WriteToken(securityToken);
        return token;
    }
}
