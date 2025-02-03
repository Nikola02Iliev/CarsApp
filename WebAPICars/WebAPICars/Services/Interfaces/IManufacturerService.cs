using Microsoft.AspNetCore.Mvc;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Filters;
using WebAPICars.Models;
using WebAPICars.Queries;

namespace WebAPICars.Services.Interfaces
{
    public interface IManufacturerService
    {
        IQueryable<Manufacturer> GetAllManufacturers(ManufacturerQueries manufacturerQueries);
        IEnumerable<Manufacturer> GetAllManufacturersForDeletion();
        Task<Manufacturer> GetManufacturerByIdAsync(int? id);
        Task<Manufacturer> GetManufacturerByIdWithCarQueiresAsync(int? id, CarQueriesInManufacturerDetails carQueriesInManufacturerDetails);
        Task PostManufacturerAsync(Manufacturer manufacturer);
        Task PutManufacturer(Manufacturer manufacturer, ManufacturerPutDTO manufacturerPutDTO);
        Task DeleteManufacturer(Manufacturer manufacturer);
        Task DeleteAllManufacturers(IEnumerable<Manufacturer> manufacturers);
        bool ManufacturerExists(int id);
        bool ManufacturerNameExists(string manufacturerName);
    }
}
