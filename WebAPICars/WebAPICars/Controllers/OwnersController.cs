using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Mappers;
using WebAPICars.Models;
using WebAPICars.Queries;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetOwners([FromQuery] OwnerQueries ownerQueries)
        {
            var owners = _ownerService.GetAllOwners(ownerQueries);

            var ToOwnerListDTO = owners.Select(o => o.ToOwnerListDTO());

            return Ok(ToOwnerListDTO);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerGetDTO>> GetOwner(int? id)
        {
            var existingOwner = await _ownerService.GetOwnerByIdAsync(id);

            if (existingOwner == null)
            {
                return NotFound($"Owner with {id} id does not exist!");
            }

            var ToOwnerGetDTO = existingOwner.ToOwnerGetDTO();

            return Ok(ToOwnerGetDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, OwnerPutDTO ownerPutDTO)
        {
            var existingOwner = await _ownerService.GetOwnerByIdAsync(id);
            if (existingOwner == null)
            {
                return NotFound($"Owner with {id} id does not exist!");
            }

            try
            {
                await _ownerService.PutOwner(existingOwner, ownerPutDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostOwner(OwnerPostDTO ownerPostDTO)
        {
            var ToOwnerModel = ownerPostDTO.ToOwnerModel();

            await _ownerService.PostOwnerAsync(ToOwnerModel);

            var OwnerGetDTOAfterPost = ToOwnerModel.ToOwnerGetDTOAfterPost();


            return CreatedAtAction("GetOwnerAfterPost", new { id = ToOwnerModel.OwnerId }, OwnerGetDTOAfterPost);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var existingOwner = await _ownerService.GetOwnerByIdAsync(id);
            if (existingOwner == null)
            {
                return NotFound($"Owner with {id} id does not exist!");
            }

            await _ownerService.DeleteOwner(existingOwner);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-all-owners")]
        public async Task<IActionResult> DeleteAllOwners()
        {
            var owners = _ownerService.GetAllOwnersForDeletion();

            await _ownerService.DeleteAllOwners(owners);

            return NoContent();
        }


        [HttpGet("after-post/{id}")]
        [ApiExplorerSettings(IgnoreApi  = true)]
        public async Task<ActionResult<OwnerGetDTOAfterPost>> GetOwnerAfterPost(int? id)
        {
            var existingOwner = await _ownerService.GetOwnerByIdAsync(id);

            if (existingOwner == null)
            {
                return NotFound($"Owner with {id} id does not exist!");
            }

            var ToOwnerGetDTOAfterPost = existingOwner.ToOwnerGetDTOAfterPost();

            return Ok(ToOwnerGetDTOAfterPost);
        }

    }
}
