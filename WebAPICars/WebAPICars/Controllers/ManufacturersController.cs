using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Mappers;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturersController(AppDBContext context, IManufacturerRepository manufacturerRepository)
        {
            _context = context;
            _manufacturerRepository = manufacturerRepository;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public IActionResult GetManufacturers()
        {
            var manufacturers = _manufacturerRepository.GetAllManufacturers();

            var manufacturersToListDTO = manufacturers.Select(m => m.ToManufacturerListDTO());

            return Ok(manufacturersToListDTO);
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerGetDTO>> GetManufacturer(int? id)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }
            
            var manufacturerToGetDTO = manufacturer.ToManufacturerGetDTO();

            
            return Ok(manufacturerToGetDTO);
        }

        // PUT: api/Manufacturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, ManufacturerPutDTO manufacturerPutDTO)
        {
            var existingManufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);
            if (existingManufacturer == null) 
            {
                return NotFound();
            
            }

            
            _manufacturerRepository.PutManufacturer(existingManufacturer, manufacturerPutDTO);

            try
            {
                await _manufacturerRepository.SaveChangesAsync();
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
            var manufacturerPostDTOToManufacturerModel = manufacturerPostDTO.ToManufacturerModelFromPost();

            await _manufacturerRepository.PostManufacturerAsync(manufacturerPostDTOToManufacturerModel);

            var manufacturerToGetDTO  = manufacturerPostDTOToManufacturerModel.ToManufacturerGetDTO();

            return CreatedAtAction("GetManufacturer", new { id = manufacturerPostDTOToManufacturerModel.ManufacturerId }, manufacturerToGetDTO);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var existingManufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);
            if(existingManufacturer == null)
            {
                return NotFound();
            }

            _manufacturerRepository.DeleteManufacturer(existingManufacturer);
            await _manufacturerRepository.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
