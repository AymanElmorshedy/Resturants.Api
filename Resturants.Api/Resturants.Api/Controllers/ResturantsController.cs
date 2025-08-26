using Microsoft.AspNetCore.Mvc;
using Resturants.Application.Dtos.Resturant;
using Resturants.Application.Services;

namespace Resturants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResturantsController(IResturantsService service ) : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          var Resturants=  await service.GetAllResturantsAsync();
            return Ok(Resturants);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Resturant = await service.GetByIdAsync(id);
            if(Resturant is null)
                return NotFound();
            return Ok(Resturant);
        }
        [HttpPost]
        public async Task<IActionResult> CreateResturant([FromBody] CreateResturantDto createResturantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           int id = await service.CreateResturantAsync(createResturantDto);
            return CreatedAtAction(nameof(GetById),new { id},null);
        }
    }
}
