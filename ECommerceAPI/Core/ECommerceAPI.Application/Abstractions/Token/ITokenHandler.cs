using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Abstractions.Token;

public interface ITokenHandler
{
    TokenDto CreateAccessToken(int minute);
}
