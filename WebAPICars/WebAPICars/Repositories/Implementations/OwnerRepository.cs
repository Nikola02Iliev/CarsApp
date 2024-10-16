using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;

namespace WebAPICars.Repositories.Implementations
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Owner> _dbSet;

        public OwnerRepository(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Owner>();
        }

        public IQueryable<Owner> GetAllOwners()
        {
            var owners = _dbSet.AsQueryable();

            return owners;
        }

        public async Task<Owner> GetOwnerByIdAsync(int? id)
        {
            var owner = await _dbSet
                .Include(o => o.Cars)
                    .ThenInclude(c => c.Manufacturer)
                .SingleOrDefaultAsync(o => o.OwnerId == id);

            return owner;
        }

        public async Task PostOwnerAsync(Owner owner)
        {
            await _dbSet.AddAsync(owner);
        }

        public void PutOwner(Owner owner, OwnerPutDTO ownerPutDTO)
        {
            owner.FirstName = ownerPutDTO.FirstName;
            owner.LastName = ownerPutDTO.LastName;
            owner.Age = ownerPutDTO.Age;
            owner.Address = ownerPutDTO.Address;
            owner.PhoneNumber = ownerPutDTO.PhoneNumber;
            owner.Email = ownerPutDTO.Email;
        }

        public void DeleteOwner(Owner owner)
        {
            _dbSet.Remove(owner);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
