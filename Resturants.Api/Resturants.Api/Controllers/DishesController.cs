using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Dishes.Commands.CreateDish;

namespace Resturants.Api.Controllers
{
    [ApiController]
    [Route("api/resturant/{resturantId}/dishes")]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int resturantId, CreateDishCommand command)
        {
            command.ResturantId = resturantId;
            await mediator.Send(command);
            return Created();
        }
    }
}
