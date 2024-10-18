using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;

namespace WebAPICars.Services.Interfaces
{
    public interface IOwnerService
    {
        IQueryable<Owner> GetAllOwners(OwnerQueries ownerQueries);
        Task <Owner> GetOwnerByIdAsync(int? id);
        Task PostOwnerAsync (Owner owner);
        Task PutOwner(Owner owner, OwnerPutDTO ownerPutDTO);
        Task DeleteOwner(Owner owner);
        bool OwnerExists(int id);
        bool PhoneNumberExists(string phoneNumber);
        bool EmailExists(string email);
    }
}
