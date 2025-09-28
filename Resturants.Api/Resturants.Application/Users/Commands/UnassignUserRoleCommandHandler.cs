using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resturants.Application.Users.Commands.UnassignUserRole;
using Resturants.Domain.Entites;
using Resturants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Users.Commands
{
    public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger ,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
    {
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Unassiging User Role {request}");
            var user =await userManager.FindByEmailAsync(request.UserEmail)
                ??throw new NotFoundException(nameof(User), request.UserEmail);
            var role = roleManager.FindByNameAsync(request.RoleName)
                ??throw new NotFoundException(nameof(User),request.RoleName);
            await userManager.RemoveFromRoleAsync(user, request.RoleName);
        }
    }
}
