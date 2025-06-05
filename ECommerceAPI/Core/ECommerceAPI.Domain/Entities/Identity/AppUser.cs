using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.Entities.Identity;

public sealed class AppUser : IdentityUser<string>
{
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", Name, SurName);
}