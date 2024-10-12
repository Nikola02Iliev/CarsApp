using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;

namespace WebAPICars.Repositories.Implementations
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Manufacturer> _dbSet;

        public ManufacturerRepository(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Manufacturer>();
        }

        
        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            var manufacturers = _dbSet.AsQueryable();

            return manufacturers;
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int? id)
        {
            var manufacturer = await _dbSet.FindAsync(id);

            return manufacturer;
        }

        public async Task PostManufacturerAsync(Manufacturer manufacturer)
        {
            await _dbSet.AddAsync(manufacturer);
            await SaveChangesAsync();
             
        }

        public void PutManufacturer(Manufacturer manufacturer, ManufacturerPutDTO manufacturerPutDTO)
        {
            manufacturer.ManufacturerName = manufacturerPutDTO.ManufacturerName;
            manufacturer.Country = manufacturerPutDTO.Country;
            manufacturer.EstablishedYear = manufacturerPutDTO.EstablishedYear;
          
        }

        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _dbSet.Remove(manufacturer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        

        
    }
}
