using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly ICarRepository _carRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository, ICarRepository carRepository)
        {
            _manufacturerRepository = manufacturerRepository;
            _carRepository = carRepository;
        }

        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            var manufacturers = _manufacturerRepository.GetAllManufacturers();

            return manufacturers;
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int? id)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);

            return manufacturer;
        }

        public async Task PostManufacturerAsync(Manufacturer manufacturer)
        {
            await _manufacturerRepository.PostManufacturerAsync(manufacturer);
            await _manufacturerRepository.SaveChangesAsync();
        }

        public async Task PutManufacturer(Manufacturer manufacturer, ManufacturerPutDTO manufacturerPutDTO)
        {
            _manufacturerRepository.PutManufacturer(manufacturer, manufacturerPutDTO);
            await _manufacturerRepository.SaveChangesAsync();
        }

        public async Task DeleteManufacturer(Manufacturer manufacturer)
        {
            var carsToDelete = _carRepository.GetAllCars().Where(c => c.ManufacturerId == manufacturer.ManufacturerId).ToList();

            _carRepository.DeleteCars(carsToDelete);

            _manufacturerRepository.DeleteManufacturer(manufacturer);
            await _manufacturerRepository.SaveChangesAsync();
        }


        public bool ManufacturerExists(int id)
        {
            return _manufacturerRepository.GetAllManufacturers().Any(m => m.ManufacturerId == id);
        }

        public bool ManufacturerNameExists(string manufacturerName)
        {
            return _manufacturerRepository.GetAllManufacturers().Any(m => m.ManufacturerName == manufacturerName);
        }

        
    }
}
