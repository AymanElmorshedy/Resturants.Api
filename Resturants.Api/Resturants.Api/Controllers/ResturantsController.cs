using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Resturants.Commands.CreateResturant;
using Resturants.Application.Resturants.Commands.DeleteResturant;
using Resturants.Application.Resturants.Commands.UpdateResturant;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ResturantDto>>> GetAll()
        {
          var Resturants=  await mediator.Send(new GetAllResturantsQuery());
            return Ok(Resturants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResturantDto?>> GetById([FromRoute] int id)
        {
            var Resturant = await mediator.Send(new GetResturantByIdQuery(id) );
          
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteResturant([FromRoute] int id)
        {
           await mediator.Send(new DeleteResturantCommand(id));
            
                return NoContent();
            
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateResturant([FromRoute]int id ,UpdateResturantCommand command)
        {
            command.Id = id;
             await mediator.Send(command);
         
            return NoContent();
        }
        
    }
}
