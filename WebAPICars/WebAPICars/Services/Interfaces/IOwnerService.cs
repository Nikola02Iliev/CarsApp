using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;

namespace WebAPICars.Services.Interfaces
{
    public interface IOwnerService
    {
        IQueryable<Owner> GetAllOwners();
        Task <Owner> GetOwnerByIdAsync(int? id);
        Task PostOwnerAsync (Owner owner);
        Task PutOwner(Owner owner, OwnerPutDTO ownerPutDTO);
        Task DeleteOwner(Owner owner);
        bool OwnerExists(int id);
    }
}
