using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;

namespace WebAPICars.Services.Interfaces
{
    public interface IOwnerService
    {
        IQueryable<Owner> GetAllOwners(OwnerQueries ownerQueries);
        IEnumerable<Owner> GetAllOwnersForDeletion();
        Task <Owner> GetOwnerByIdAsync(int? id);
        Task PostOwnerAsync (Owner owner);
        Task PutOwner(Owner owner, OwnerPutDTO ownerPutDTO);
        Task DeleteOwner(Owner owner);
        Task DeleteAllOwners(IEnumerable<Owner> owners);
        bool OwnerExists(int id);
        bool PhoneNumberExists(string phoneNumber);
        bool EmailExists(string email);
    }
}
