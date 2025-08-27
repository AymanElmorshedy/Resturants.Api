using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Resturants.Commands.CreateResturant;
using Resturants.Application.Resturants.Commands.DeleteResturant;
using Resturants.Application.Resturants.Dtos;
using Resturants.Application.Resturants.Queries.GetAllResturants;
using Resturants.Application.Resturants.Queries.GetResturantById;


namespace Resturants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResturantsController(IMediator mediator ) : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          var Resturants=  await mediator.Send(new GetAllResturantsQuery());
            return Ok(Resturants);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Resturant = await mediator.Send(new GetResturantByIdQuery(id) );
            if(Resturant is null)
                return NotFound();
            return Ok(Resturant);
        }
        [HttpPost]
        public async Task<IActionResult> CreateResturant([FromBody] CreateResturantCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById),new { id},null);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant([FromRoute] int id)
        {
            var IsDeleted = await mediator.Send(new DeleteResturantCommand(id));
            if(IsDeleted)
                return NoContent();
            return NotFound();
        }
    }
}
