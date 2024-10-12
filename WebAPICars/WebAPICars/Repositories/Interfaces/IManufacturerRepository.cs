using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;

namespace WebAPICars.Repositories.Interfaces
{
    public interface IManufacturerRepository
    {
        IQueryable<Manufacturer> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerByIdAsync(int? id);
        Task PostManufacturerAsync(Manufacturer manufacturer);
        void PutManufacturer(Manufacturer manufacturer, ManufacturerPutDTO manufacturerPutDTO);
        void DeleteManufacturer(Manufacturer manufacturer);
        Task SaveChangesAsync();
        
    }
}
