using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

       

        public IQueryable<Owner> GetAllOwners()
        {
            var owners = _ownerRepository.GetAllOwners();

            return owners;
        }

        public async Task<Owner> GetOwnerByIdAsync(int? id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);

            return owner;
        }

        public async Task PostOwnerAsync(Owner owner)
        {
            await _ownerRepository.PostOwnerAsync(owner);
            await _ownerRepository.SaveChangesAsync();
        }

        public async Task PutOwner(Owner owner, OwnerPutDTO ownerPutDTO)
        {
            _ownerRepository.PutOwner(owner, ownerPutDTO);
            await _ownerRepository.SaveChangesAsync();
        }

        public async Task DeleteOwner(Owner owner)
        {
            _ownerRepository.DeleteOwner(owner);
            await _ownerRepository.SaveChangesAsync();
        }

        public bool OwnerExists(int id)
        {
            return _ownerRepository.GetAllOwners().Any(o => o.OwnerId == id);
        }

        public bool PhoneNumberExists(string phoneNumber)
        {
            return _ownerRepository.GetAllOwners().Any(o => o.PhoneNumber == phoneNumber);
        }

        public bool EmailExists(string email)
        {
            return _ownerRepository.GetAllOwners().Any(o => o.Email == email);
        }
    }
}
