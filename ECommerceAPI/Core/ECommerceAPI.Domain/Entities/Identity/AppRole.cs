using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.Entities.Identity;

public sealed class AppRole : IdentityRole<string>
{
}