using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Filters;
using WebAPICars.Mappers;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {

        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }


        // GET: api/Manufacturers
        [HttpGet]
        public IActionResult GetManufacturers([FromQuery] ManufacturerQueries manufacturerQueries)
        {
            var manufacturers = _manufacturerService.GetAllManufacturers(manufacturerQueries);

            var manufacturersToListDTO = manufacturers.Select(m => m.ToManufacturerListDTO());

            return Ok(manufacturersToListDTO);
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerGetDTO>> GetManufacturer(int? id)
        {
            var existingManufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);

            if (existingManufacturer == null)
            {
                return NotFound($"Manufacturer with {id} id does not exist!");
            }

            var manufacturerToGetDTO = existingManufacturer.ToManufacturerGetDTO();


            return Ok(manufacturerToGetDTO);
        }

        // PUT: api/Manufacturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, ManufacturerPutDTO manufacturerPutDTO)
        {
            var existingManufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
            if (existingManufacturer == null)
            {
                return NotFound($"Manufacturer with {id} id does not exist!");
            }

            try
            {
                await _manufacturerService.PutManufacturer(existingManufacturer, manufacturerPutDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        // POST: api/Manufacturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostManufacturer(ManufacturerPostDTO manufacturerPostDTO)
        {
            var ToManufacturerModel = manufacturerPostDTO.ToManufacturerModel();

            await _manufacturerService.PostManufacturerAsync(ToManufacturerModel);

            var manufacturerToGetDTOAfterPost = ToManufacturerModel.ToManufacturerGetDTOAfterPost();

            return CreatedAtAction("GetManufacturerAfterPost", new { id = ToManufacturerModel.ManufacturerId }, manufacturerToGetDTOAfterPost);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var existingManufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
            if (existingManufacturer == null)
            {
                return NotFound($"Manufacturer with {id} id does not exist!");
            }

            await _manufacturerService.DeleteManufacturer(existingManufacturer);

            return NoContent();
        }

        [HttpGet("after-post/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<ManufacturerGetDTOAfterPost>> GetManufacturerAfterPost(int? id)
        {
            var existingManufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);

            if (existingManufacturer == null)
            {
                return NotFound($"Manufacturer with {id} id does not exist!");
            }

            var manufacturerToGetDTOAfterPost = existingManufacturer.ToManufacturerGetDTOAfterPost();


            return Ok(manufacturerToGetDTOAfterPost);
        }

    }
}
