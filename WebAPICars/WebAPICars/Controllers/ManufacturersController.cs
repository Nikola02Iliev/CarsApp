using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Mappers;
using WebAPICars.Models;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ManufacturersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<List<ManufacturerListDTO>>> GetManufacturers()
        {
            var manufacturers = await _context.Manufacturer.ToListAsync();

            var manufacturersToListDTO = manufacturers.Select(m =>m.ToManufacturerListDTO()).ToList();

            return manufacturersToListDTO;
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerGetDTO>> GetManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }


            var manufacturerToGetDTO = manufacturer.ToManufacturerGetDTO();

            
            return manufacturerToGetDTO;
        }

        // PUT: api/Manufacturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, ManufacturerPutDTO manufacturerPutDTO)
        {

            var manufacturerPutDTOToManufacturerModel = manufacturerPutDTO.ToManufacturerModelFromPut();

            manufacturerPutDTOToManufacturerModel.ManufacturerId = id;

            _context.Entry(manufacturerPutDTOToManufacturerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Manufacturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(ManufacturerPostDTO manufacturerPostDTO)
        {
            var manufacturerPostDTOToManufacturerModel = manufacturerPostDTO.ToManufacturerModelFromPost();

            _context.Manufacturer.Add(manufacturerPostDTOToManufacturerModel);
            await _context.SaveChangesAsync();

            var manufacturerToGetDTO  = manufacturerPostDTOToManufacturerModel.ToManufacturerGetDTO();

            return CreatedAtAction("GetManufacturer", new { id = manufacturerPostDTOToManufacturerModel.ManufacturerId }, manufacturerToGetDTO);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturer.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturer.Any(e => e.ManufacturerId == id);
        }
    }
}
