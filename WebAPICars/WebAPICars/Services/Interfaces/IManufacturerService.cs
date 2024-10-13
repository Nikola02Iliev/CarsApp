using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;

namespace WebAPICars.Services.Interfaces
{
    public interface IManufacturerService
    {
        IQueryable<Manufacturer> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerByIdAsync(int? id);
        Task PostManufacturerAsync(Manufacturer manufacturer);
        Task PutManufacturer(Manufacturer manufacturer, ManufacturerPutDTO manufacturerPutDTO);
        Task DeleteManufacturer(Manufacturer manufacturer);
    }
}
