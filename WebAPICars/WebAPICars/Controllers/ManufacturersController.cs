﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Filters;
using WebAPICars.Mappers;
using WebAPICars.Queries;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {

        private readonly IManufacturerService _manufacturerService;
        private readonly IImageService _imageService;

        public ManufacturersController(IManufacturerService manufacturerService, IImageService imageService)
        {
            _manufacturerService = manufacturerService;
            _imageService = imageService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetManufacturers([FromQuery] ManufacturerQueries manufacturerQueries)
        {
            var manufacturers = _manufacturerService.GetAllManufacturers(manufacturerQueries);

            var manufacturersToListDTO = manufacturers.Select(m => m.ToManufacturerListDTO());

            return Ok(manufacturersToListDTO);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerGetDTO>> GetManufacturer(int? id, [FromQuery] CarQueriesInManufacturerDetails carQueriesInManufacturerDetails)
        {
            var existingManufacturer = await _manufacturerService.GetManufacturerByIdWithCarQueiresAsync(id, carQueriesInManufacturerDetails);

            if (existingManufacturer == null)
            {
                return NotFound($"Manufacturer with {id} id does not exist!");
            }

            var manufacturerToGetDTO = existingManufacturer.ToManufacturerGetDTO();


            return Ok(manufacturerToGetDTO);
        }

        [Authorize(Roles = "Admin")]
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


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostManufacturer(ManufacturerPostDTO manufacturerPostDTO)
        {
            var ToManufacturerModel = manufacturerPostDTO.ToManufacturerModel();

            await _manufacturerService.PostManufacturerAsync(ToManufacturerModel);

            var manufacturerToGetDTOAfterPost = ToManufacturerModel.ToManufacturerGetDTOAfterPost();

            return CreatedAtAction("GetManufacturerAfterPost", new { id = ToManufacturerModel.ManufacturerId }, manufacturerToGetDTOAfterPost);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var existingManufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);
            if (existingManufacturer == null)
            {
                return NotFound($"Manufacturer with {id} id does not exist!");
            }

            _imageService.DeleteImages(existingManufacturer.Cars.AsEnumerable());

            await _manufacturerService.DeleteManufacturer(existingManufacturer);
            

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-all-manufacturers")]
        public async Task<ActionResult> DeleteAllManufacturers()
        {
            
            var manufacturers = _manufacturerService.GetAllManufacturersForDeletion();

            _imageService.DeleteImagesAfterDeletionOfManufacturers(manufacturers);

            await _manufacturerService.DeleteAllManufacturers(manufacturers);

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
