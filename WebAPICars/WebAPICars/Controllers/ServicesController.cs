using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Mappers;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }



        // GET: api/Services
        [HttpGet]
        public IActionResult GetServices()
        {
            var services = _serviceService.GetAllServices();

            var ToServiceListDTO = services.Select(s => s.ToServiceListDTO());

            return Ok(ToServiceListDTO);

        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceGetDTO>> GetService(int? id)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);

            if (existingService == null)
            {
                return NotFound($"Service with {id} id does not exist!");
            }

            var ToServiceGetDTO = existingService.ToServiceGetDTO();

            return Ok(ToServiceGetDTO);
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, ServicePutDTO servicePutDTO)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);

            if (existingService == null)
            {
                return NotFound($"Service with {id} id does not exist!");
            }


            try
            {
                await _serviceService.PutService(existingService, servicePutDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        //POST: api/Services
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{carId}")]
        public async Task<ActionResult> PostService(ServicePostDTO servicePostDTO, int carId)
        {
            var ToServiceModel = servicePostDTO.ToServiceModel();

            await _serviceService.PostServiceAsync(ToServiceModel, carId);

            var ToServiceGetDTOAfterPost = ToServiceModel.ToServiceGetDTOAfterPost();

            return CreatedAtAction("GetServiceAfterPost", new { id = ToServiceModel.ServiceId }, ToServiceGetDTOAfterPost);
        }


        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);
            if (existingService == null)
            {
                return NotFound($"Service with {id} id does not exist!");
            }

            await _serviceService.DeleteService(existingService);

            return NoContent();
        }

        [HttpGet("after-post/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<ServiceGetDTOAfterPost>> GetServiceAfterPost(int? id)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);

            if (existingService == null)
            {
                return NotFound($"Service with {id} id does not exist!");
            }


            var ToServiceGetDTOAfterPost = existingService.ToServiceGetDTOAfterPost();

            return Ok(ToServiceGetDTOAfterPost);
        }
    }
}
