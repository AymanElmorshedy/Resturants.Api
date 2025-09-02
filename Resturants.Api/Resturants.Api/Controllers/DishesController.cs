using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Dishes.Commands.CreateDish;
using Resturants.Application.Dishes.Commands.DeleteDishes;
using Resturants.Application.Dishes.Dtos;
using Resturants.Application.Dishes.Querires;
using Resturants.Application.Dishes.Querires.GetAllDishes;
using Resturants.Application.Dishes.Querires.GetDishById;

namespace Resturants.Api.Controllers
{
    [Route("api/resturant/{resturantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int resturantId, CreateDishCommand command)
        {
            command.ResturantId = resturantId;
            var dishId =  await mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdForResturant), new {resturantId,dishId},null);  
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForResturants([FromRoute] int resturantId)
        {
           var dishes= await mediator.Send(new GetDishesForResturantQuery(resturantId));
            return Ok(dishes);
        }
        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForResturant([FromRoute] int resturantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForResturantQuery(resturantId, dishId));
            return Ok(dish);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDishesForResturant([FromRoute] int resturantId)
        {
            await mediator.Send(new DeleteDishesForResturantCommand(resturantId));
            return NoContent();
        }
    }
}
