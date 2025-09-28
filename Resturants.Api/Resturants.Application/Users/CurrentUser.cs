using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Users
{
    public record CurrentUser(string Id, string Email,IEnumerable<string> Roles,string? Nationality,DateOnly? DateOfBirth)
    {
        public bool IsInRole(string Role) => Roles.Contains(Role);

    }
}
