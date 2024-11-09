using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Mappers;
using WebAPICars.Models;
using WebAPICars.Queries;
using WebAPICars.Services.Implementations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IOwnerService _ownerService;
        private readonly IServiceService _serviceService;
        private readonly IImageService _imageService;

        public CarsController(ICarService carService, IManufacturerService manufacturerService, IOwnerService ownerService, IImageService imageService, IServiceService serviceService)
        {
            _carService = carService;
            _manufacturerService = manufacturerService;
            _ownerService = ownerService;
            _imageService = imageService;
            _serviceService = serviceService;
        }

        // GET: api/Cars
        [HttpGet]
        public IActionResult GetCars([FromQuery] CarQueries carQueries)
        {
            var cars = _carService.GetAllCars(carQueries);

            if (cars.Count() == 0)
            {
                return NotFound("No cars found");
            }

            var carsToListDTO = cars.Select(c => c.ToCarListDTO());

            return Ok(carsToListDTO);
            
        }

        [HttpGet("get-cars-without-owner")]
        public IActionResult GetCarsWithoutOwner([FromQuery] CarQueries carQueries)
        {
            var cars = _carService.GetCarsWithoutOwner(carQueries);

            var carsToListDTO = cars.Select(c => c.ToCarListDTO());

            return Ok(carsToListDTO);

        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarGetDTO>> GetCar(int? id)
        {
            var existingCar = await _carService.GetCarByIdAsync(id);

            if (existingCar == null)
            {
                return NotFound($"Car with {id} id does not exist!");
            }

            var carToGetDTO = existingCar.ToCarGetDTO();

            return Ok(carToGetDTO);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarPutDTO carPutDTO)
        {
            var existingCar = await _carService.GetCarByIdAsync(id);
            if(existingCar == null)
            {
                return NotFound($"Car with {id} id does not exist!");
            }

            try
            {
                if (carPutDTO.Image != null) 
                {
                    await _imageService.UpdateImageAsync(carPutDTO, existingCar);
                }
                await _carService.PutCar(existingCar, carPutDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        [HttpPut("put-ownerid-car/{id}/{ownerId}")]
        public async Task<IActionResult> PutCar(int id, int ownerId)
        {
            var existingCar = await _carService.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound($"Car with {id} id does not exist!");
            }

            var existingOwner = _ownerService.OwnerExists(ownerId);
            if (!existingOwner)
            {
                return NotFound($"Owner with {ownerId} id does not exist!");
            }

            try
            {
                await _carService.PutCarOwnerId(existingCar, ownerId);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{manufacturerId}/{ownerId}")]
        public async Task<ActionResult> PostCar(CarPostDTO carPostDTO, int manufacturerId, int ownerId)
        {
            if (!_manufacturerService.ManufacturerExists(manufacturerId))
            {
                return NotFound($"Manufacturer with {manufacturerId} id does not exist!");
            }

            if (!_ownerService.OwnerExists(ownerId))
            {
                return NotFound($"Owner with {ownerId} id does not exist!");
            }

            var ToCarModel = carPostDTO.ToCarModel();

            await _imageService.SaveImageAsync(carPostDTO, ToCarModel);

            await _carService.PostCarAsync(ToCarModel, manufacturerId, ownerId);

            var carToGetDTOAfterPost = ToCarModel.ToCarGetDTOAfterPost();

            return CreatedAtAction("GetCarAfterPost", new { id = ToCarModel.CarId }, carToGetDTOAfterPost);
        }


        [HttpPost("post-car-without-owner/{manufacturerId}")]
        public async Task<ActionResult> PostCarWithoutOwner(CarPostDTO carPostDTO, int manufacturerId)
        {
            if (!_manufacturerService.ManufacturerExists(manufacturerId))
            {
                return NotFound($"Manufacturer with {manufacturerId} id does not exist!");
            }

            var ToCarModel = carPostDTO.ToCarModel();

            await _imageService.SaveImageAsync(carPostDTO, ToCarModel);

            await _carService.PostCarWithoutOwnerAsync(ToCarModel, manufacturerId);

            var carToGetDTOAfterPost = ToCarModel.ToCarGetDTOAfterPost();


            return CreatedAtAction("GetCarAfterPost", new { id = ToCarModel.CarId }, carToGetDTOAfterPost);

        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            
            var existingCar = await _carService.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound($"Car with {id} id does not exist!");
            }

            _imageService.DeleteImage(existingCar);

            await _carService.DeleteCar(existingCar);


            return NoContent();
        }

        [HttpDelete("delete-all-cars")]
        public async Task<IActionResult> DeleteAllCars()
        {
            var cars = _carService.GetAllCarsForDeletion();

            _imageService.DeleteImages(cars);

            await _carService.DeleteAllCars(cars);

            return NoContent();
        }


        [HttpGet("after-post/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<CarGetDTOAfterPost>> GetCarAfterPost(int? id)
        {
            var existingCar = await _carService.GetCarByIdAsync(id);

            if (existingCar == null)
            {
                return NotFound($"Car with {id} id does not exist!");
            }

            var carToGetDTOAfterPost = existingCar.ToCarGetDTOAfterPost();

            return Ok(carToGetDTOAfterPost);
        }



    }
}
