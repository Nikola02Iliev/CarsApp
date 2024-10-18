using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Filters;
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

        public IQueryable<Manufacturer> GetAllManufacturers(ManufacturerQueries manufacturerQueries)
        {
            var manufacturers = _manufacturerRepository.GetAllManufacturers();

            if (!string.IsNullOrWhiteSpace(manufacturerQueries.ManufacturerName))
            {
                manufacturers = manufacturers.Where(m => m.ManufacturerName.Contains(manufacturerQueries.ManufacturerName));
            }

            if (!string.IsNullOrWhiteSpace(manufacturerQueries.Country))
            {
                manufacturers = manufacturers.Where(m => m.Country.Contains(manufacturerQueries.Country));
            }

            if (manufacturerQueries.EstablishedYear != null)
            {
                manufacturers = manufacturers.Where(m => m.EstablishedYear.Equals(manufacturerQueries.EstablishedYear));

            }

            if (!string.IsNullOrWhiteSpace(manufacturerQueries.SortBy))
            {
                if(manufacturerQueries.SortBy == "Country")
                {
                    if (manufacturerQueries.IsDescending)
                    {
                        manufacturers = manufacturers.OrderByDescending(m => m.Country);
                    }
                    else
                    {
                        manufacturers = manufacturers.OrderBy(m => m.Country);
                    }
                }

                if (manufacturerQueries.SortBy == "ManufacturerName")
                {
                    if (manufacturerQueries.IsDescending)
                    {
                        manufacturers = manufacturers.OrderByDescending(m => m.ManufacturerName);
                    }
                    else
                    {
                        manufacturers = manufacturers.OrderBy(m => m.ManufacturerName);
                    }
                }

                if (manufacturerQueries.SortBy == "EstablishedYear")
                {
                    if (manufacturerQueries.IsDescending)
                    {
                        manufacturers = manufacturers.OrderByDescending(m => m.EstablishedYear);
                    }
                    else
                    {
                        manufacturers = manufacturers.OrderBy(m => m.EstablishedYear);
                    }
                }

            }

            var skipNumber = (manufacturerQueries.PageNumber - 1) * manufacturerQueries.PageSize;
            var takeNumber = manufacturerQueries.PageSize;

            return manufacturers.Skip(skipNumber).Take(takeNumber);
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
