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
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IManufacturerService _manufacturerService;

        public CarsController(ICarService carService, IManufacturerService manufacturerService)
        {
            _carService = carService;
            _manufacturerService = manufacturerService;
        }

        // GET: api/Cars
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetAllCars();

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
                return NotFound();
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
                return NotFound();
            }

            try
            {
                await _carService.PutCar(existingCar, carPutDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{manufacturerId}")]
        public async Task<ActionResult<Car>> PostCar(CarPostDTO carPostDTO, int manufacturerId)
        {
            if (!_manufacturerService.ManufacturerExists(manufacturerId))
            {
                return BadRequest("Manufacturer does not exist.");
            }

            var ToCarModel = carPostDTO.ToCarModel();

            await _carService.PostCarAsync(ToCarModel, manufacturerId);

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
                return NotFound();
            }

            await _carService.DeleteCar(existingCar);

            return NoContent();
        }


        [HttpGet("after-post/{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<CarGetDTOAfterPost>> GetCarAfterPost(int? id)
        {
            var existingCar = await _carService.GetCarByIdAsync(id);

            if (existingCar == null)
            {
                return NotFound();
            }

            var carToGetDTOAfterPost = existingCar.ToCarGetDTOAfterPost();

            return Ok(carToGetDTOAfterPost);
        }



    }
}
