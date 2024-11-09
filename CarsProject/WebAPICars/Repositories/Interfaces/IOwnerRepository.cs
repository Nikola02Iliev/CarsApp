using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;

namespace WebAPICars.Repositories.Interfaces
{
    public interface IOwnerRepository
    {
        IQueryable<Owner> GetAllOwners();
        Task <Owner> GetOwnerByIdAsync(int? id);
        Task PostOwnerAsync (Owner owner);
        void PutOwner(Owner owner, OwnerPutDTO ownerPutDTO);
        void DeleteOwner(Owner owner);
        void DeleteOwners(IEnumerable<Owner> owners);
        Task SaveChangesAsync();
    }
}
