using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Mappers;
using WebAPICars.Queries;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly ICarService _carService;

        public ServicesController(IServiceService serviceService, ICarService carService)
        {
            _serviceService = serviceService;
            _carService = carService;
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetServices([FromQuery] ServiceQueries serviceQueries)
        {
            var services = _serviceService.GetAllServices(serviceQueries);

            var ToServiceListDTO = services.Select(s => s.ToServiceListDTO());

            return Ok(ToServiceListDTO);

        }

        [AllowAnonymous]
        [HttpGet("repaired-cars")]
        public IActionResult GetServicesWihtRepairedCars([FromQuery] ServiceQueries serviceQueries)
        {
            var services = _serviceService.GetAllServicesWithRepairedCars(serviceQueries);

            var ToServiceListDTO = services.Select(s => s.ToServiceListDTO());

            return Ok(ToServiceListDTO);

        }

        [AllowAnonymous]
        [HttpGet("not-repaired-cars")]
        public IActionResult GetServicesWihtNotRepairedCars([FromQuery] ServiceQueries serviceQueries)
        {
            var services = _serviceService.GetAllServicesWithNotRepairedCars(serviceQueries);

            var ToServiceListDTO = services.Select(s => s.ToServiceListDTO());

            return Ok(ToServiceListDTO);

        }

        [AllowAnonymous]
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, ServicePutDTO servicePutDTO)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);

            if (existingService == null)
            {
                return NotFound($"Service with {id} id does not exist!");
            }

            var startServiceDateTime = existingService.StartServiceDate;
            var startServiceDateOnly = DateOnly.FromDateTime(startServiceDateTime);

            var endServiceDateTime = DateTime.Parse(servicePutDTO.EndServiceDate);
            var endServiceDateOnly = DateOnly.FromDateTime(endServiceDateTime);

            if (startServiceDateOnly > endServiceDateOnly) 
            {
                return BadRequest($"End service date must be later than {startServiceDateOnly:yyyy-MM-dd}!");
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

        [Authorize(Roles = "Admin")]
        [HttpPut("repair-car/{id}")]
        public async Task<IActionResult> PutServiceIsCarRepairToTrue(int? id)
        {
            var existingService = await _serviceService.GetServiceByIdAsync(id);

            if (existingService == null)
            {
                return NotFound($"Service with {id} id does not exist!");
            }

            if(existingService.IsCarRepaired == true)
            {
                return BadRequest($"Car with {id} id is already repaired!");
            }


            try
            {
                await _serviceService.PutServiceIsCarRepairedToTrue(existingService);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        [Authorize]
        [HttpPost("{carId}")]
        public async Task<ActionResult> PostService(ServicePostDTO servicePostDTO, int carId)
        {

            if (_carService.IsCarInService(carId))
            {
                return BadRequest("Car is already in service!");
            }

            if(await _carService.IsCarWithoutOwner(carId))
            {
                return BadRequest("Car has no owner!");
            }


            var ToServiceModel = servicePostDTO.ToServiceModel();

            await _serviceService.PostServiceAsync(ToServiceModel, carId);

            var ToServiceGetDTOAfterPost = ToServiceModel.ToServiceGetDTOAfterPost();

            return CreatedAtAction("GetServiceAfterPost", new { id = ToServiceModel.ServiceId }, ToServiceGetDTOAfterPost);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-all-services")]
        public async Task<IActionResult> DeleteAllServices()
        {
            var services = _serviceService.GetAllServicesForDeletion();

            await _serviceService.DeleteAllServices(services);

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
