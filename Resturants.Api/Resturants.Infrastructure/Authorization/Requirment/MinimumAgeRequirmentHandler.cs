using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Resturants.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Authorization.Requirment
{
    public class MinimumAgeRequirmentHandler(ILogger<MinimumAgeRequirmentHandler> logger 
        ,IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirment requirement)
        {
            var CurrentUser = userContext.GetCurrentUser();
            
            logger.LogInformation("User : {Email}, {DateOfBirth} - Handeling MinimumAgeReqirment"
                ,CurrentUser.Email,
                CurrentUser.DateOfBirth);
            if (CurrentUser.DateOfBirth is null)
            {
                logger.LogWarning("Authorization Failed: No Date of Birth Claim");
                context.Fail();
                return Task.CompletedTask;
            }
            if(CurrentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.UtcNow))
            {
                logger.LogInformation("Authorization Succeeded");
                context.Succeed(requirement);
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
