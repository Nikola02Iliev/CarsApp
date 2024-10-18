using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Filters;
using WebAPICars.Models;

namespace WebAPICars.Services.Interfaces
{
    public interface IManufacturerService
    {
        IQueryable<Manufacturer> GetAllManufacturers(ManufacturerQueries manufacturerQueries);
        Task<Manufacturer> GetManufacturerByIdAsync(int? id);
        Task PostManufacturerAsync(Manufacturer manufacturer);
        Task PutManufacturer(Manufacturer manufacturer, ManufacturerPutDTO manufacturerPutDTO);
        Task DeleteManufacturer(Manufacturer manufacturer);
        bool ManufacturerExists(int id);
        bool ManufacturerNameExists(string manufacturerName);
    }
}
