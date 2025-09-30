using Microsoft.Extensions.Logging;
using Resturants.Application.Users;
using Resturants.Domain.Constants;
using Resturants.Domain.Entites;
using Resturants.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Authorization.Services;

public class ResturantAuthorizationService(ILogger<ResturantAuthorizationService> logger, IUserContext userContext) : IResturantAuthorizationService
{
    public bool Authorize(Resturant resturant, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation($"Authorize {user.Email}, to {resourceOperation} for {resturant.Name}");
        if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
        {
            logger.LogInformation("Create and read operation - successful authorization ");
            return true;
        }
        if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Delete operation by admin - successful authorization ");
            return true;
        }
        if (resturant.OwnerId == user.Id && resourceOperation == ResourceOperation.Update)
        {
            logger.LogInformation("Resturant owner - successful authorization ");
            return true;
        }
        return false;
    }


}
