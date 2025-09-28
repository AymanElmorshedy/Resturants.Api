using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Users.Commands.AssignUserRole;
using Resturants.Application.Users.Commands.UnassignUserRole;
using Resturants.Application.Users.Commands.UpdateUserDetails;
using Resturants.Domain.Constants;

namespace Resturants.Api.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IMediator mediator):ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand Command)
        {
           await mediator.Send(Command);
            return NoContent();
        }
        [HttpPost("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("userRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
