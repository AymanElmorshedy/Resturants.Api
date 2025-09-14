using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Users.Commands;

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
    }
}
