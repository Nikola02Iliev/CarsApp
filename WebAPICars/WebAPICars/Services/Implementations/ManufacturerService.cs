using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Filters;
using WebAPICars.Models;
using WebAPICars.Queries;
using WebAPICars.Repositories.Implementations;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly ICarRepository _carRepository;
        private readonly IServiceRepository _serviceRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository, ICarRepository carRepository, IServiceRepository serviceRepository)
        {
            _manufacturerRepository = manufacturerRepository;
            _carRepository = carRepository;
            _serviceRepository = serviceRepository;
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

        public IEnumerable<Manufacturer> GetAllManufacturersForDeletion()
        {
            var manufacturers = _manufacturerRepository.GetAllManufacturers().AsEnumerable();

            return manufacturers;
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int? id)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);

            return manufacturer;
        }

        public async Task<Manufacturer> GetManufacturerByIdWithCarQueiresAsync(int? id, CarQueriesInManufacturerDetails carQueriesInManufacturerDetails)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(id);



            var skipNumber = (carQueriesInManufacturerDetails.PageNumber - 1) * carQueriesInManufacturerDetails.PageSize;
            var takeNumber = carQueriesInManufacturerDetails.PageSize;

            var manufacturerCars = manufacturer.Cars.Skip(skipNumber).Take(takeNumber);

            manufacturer.Cars = manufacturerCars.ToList();
           
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
            var carsToDelete = _carRepository.GetAllCars().Where(c => c.ManufacturerId == manufacturer.ManufacturerId).AsEnumerable();

            foreach (var car in carsToDelete) 
            {
                var service = _serviceRepository.GetAllServices().SingleOrDefault(s => s.CarId == car.CarId);
                if (service != null)
                {
                    _serviceRepository.DeleteService(service);
                }
            }

            _carRepository.DeleteCars(carsToDelete);

            _manufacturerRepository.DeleteManufacturer(manufacturer);
            await _manufacturerRepository.SaveChangesAsync();
        }

        public async Task DeleteAllManufacturers(IEnumerable<Manufacturer> manufacturers)
        {
            foreach(var manufacturer in manufacturers)
            {
                var carsToDelete = _carRepository.GetAllCars().Where(c => c.ManufacturerId == manufacturer.ManufacturerId).AsEnumerable();
                foreach(var car in carsToDelete)
                {
                    var service = _serviceRepository.GetAllServices().SingleOrDefault(s => s.CarId == car.CarId);
                    if(service != null)
                    {
                        _serviceRepository.DeleteService(service);
                    }

                }

                _carRepository.DeleteCars(carsToDelete);
                _manufacturerRepository.DeleteManufacturer(manufacturer);
            }

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
