using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs;

public sealed class TokenDto
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime ExpirationTime{ get; set; }
}
