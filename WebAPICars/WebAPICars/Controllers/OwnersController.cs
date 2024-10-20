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



        // GET: api/Owners
        [HttpGet]
        public IActionResult GetOwners([FromQuery] OwnerQueries ownerQueries)
        {
            var owners = _ownerService.GetAllOwners(ownerQueries);

            var ToOwnerListDTO = owners.Select(o => o.ToOwnerListDTO());

            return Ok(ToOwnerListDTO);
        }

        // GET: api/Owners/5
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

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostOwner(OwnerPostDTO ownerPostDTO)
        {
            var ToOwnerModel = ownerPostDTO.ToOwnerModel();

            await _ownerService.PostOwnerAsync(ToOwnerModel);

            var OwnerGetDTOAfterPost = ToOwnerModel.ToOwnerGetDTOAfterPost();


            return CreatedAtAction("GetOwnerAfterPost", new { id = ToOwnerModel.OwnerId }, OwnerGetDTOAfterPost);
        }

        // DELETE: api/Owners/5
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
