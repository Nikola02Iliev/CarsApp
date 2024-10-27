using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IServiceRepository _serviceRepository;

        public CarService(ICarRepository carRepository, IServiceRepository serviceRepository)
        {
            _carRepository = carRepository;
            _serviceRepository = serviceRepository;
        }


        public IQueryable<Car> GetAllCars(CarQueries carQueries)
        {
            var cars = _carRepository.GetAllCars();

            if (!string.IsNullOrWhiteSpace(carQueries.Model))
            {
                cars = cars.Where(c => c.Model.Contains(carQueries.Model));
            }

            if (carQueries.Price != null) 
            {
                cars = cars.Where(c => c.Price.Equals(carQueries.Price));
            }

            if (carQueries.Year != null)
            {
                cars = cars.Where(c => c.Year.Equals(carQueries.Year));
            }

            if (!string.IsNullOrWhiteSpace(carQueries.Color))
            {
                cars = cars.Where(c => c.Color.Contains(carQueries.Color));
            }

            if (!string.IsNullOrWhiteSpace(carQueries.LicensePlate))
            {
                cars = cars.Where(c => c.LicensePlate.Contains(carQueries.LicensePlate));

            }

            if (!string.IsNullOrWhiteSpace(carQueries.SortBy))
            {
                if(carQueries.SortBy == "Model")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Model);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Model);

                    }
                }

                if (carQueries.SortBy == "Price")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Price);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Price);

                    }
                }

                if (carQueries.SortBy == "Year")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Year);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Year);

                    }
                }

                if (carQueries.SortBy == "Color")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Color);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Color);

                    }
                }

                if (carQueries.SortBy == "LicensePlate")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.LicensePlate);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.LicensePlate);

                    }
                }
            }

            var skipNumber = (carQueries.PageNumber - 1) * carQueries.PageSize;
            var takeNumber = carQueries.PageSize;


            return cars.Skip(skipNumber).Take(takeNumber);
        }

        public async Task<Car> GetCarByIdAsync(int? id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);

            return car;
        }

        public async Task PostCarAsync(Car car, int? manufacturerId, int? ownerId)
        {
            car.ManufacturerId = manufacturerId;
            car.OwnerId = ownerId;
            await _carRepository.PostCarAsync(car);
            await _carRepository.SaveChangesAsync();
        }

        public async Task PutCar(Car car, CarPutDTO carPutDTO)
        {
            _carRepository.PutCar(car, carPutDTO);
            await _carRepository.SaveChangesAsync();
        }

        public async Task DeleteCar(Car car)
        {
            _carRepository.DeleteCar(car);
            await _carRepository.SaveChangesAsync();
        }

        public bool LicensePlateExists(string licensePlate)
        {
            return _carRepository.GetAllCars().Any(c => c.LicensePlate == licensePlate);
        }

        public IQueryable<Car> GetCarsWithoutOwner(CarQueries carQueries)
        {
            var cars = _carRepository.GetAllCars();

            cars = cars.Where(c => c.OwnerId == null);

            if (!string.IsNullOrWhiteSpace(carQueries.Model))
            {
                cars = cars.Where(c => c.Model.Contains(carQueries.Model));
            }

            if (carQueries.Price != null)
            {
                cars = cars.Where(c => c.Price.Equals(carQueries.Price));
            }

            if (carQueries.Year != null)
            {
                cars = cars.Where(c => c.Year.Equals(carQueries.Year));
            }

            if (!string.IsNullOrWhiteSpace(carQueries.Color))
            {
                cars = cars.Where(c => c.Color.Contains(carQueries.Color));
            }

            if (!string.IsNullOrWhiteSpace(carQueries.LicensePlate))
            {
                cars = cars.Where(c => c.LicensePlate.Contains(carQueries.LicensePlate));

            }

            if (!string.IsNullOrWhiteSpace(carQueries.SortBy))
            {
                if (carQueries.SortBy == "Model")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Model);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Model);

                    }
                }

                if (carQueries.SortBy == "Price")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Price);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Price);

                    }
                }

                if (carQueries.SortBy == "Year")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Year);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Year);

                    }
                }

                if (carQueries.SortBy == "Color")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.Color);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.Color);

                    }
                }

                if (carQueries.SortBy == "LicensePlate")
                {
                    if (carQueries.IsDescending)
                    {
                        cars = cars.OrderByDescending(c => c.LicensePlate);
                    }
                    else
                    {
                        cars = cars.OrderBy(c => c.LicensePlate);

                    }
                }
            }

            var skipNumber = (carQueries.PageNumber - 1) * carQueries.PageSize;
            var takeNumber = carQueries.PageSize;

            return cars;

        }

        public async Task PostCarWithoutOwnerAsync(Car car, int? manufacturerId)
        {
            car.ManufacturerId = manufacturerId;
            await _carRepository.PostCarAsync(car);
            await _carRepository.SaveChangesAsync();
        }

        public async Task PutCarOwnerId(Car car, int? ownerId)
        {
            _carRepository.PutCarOwnerId(car, ownerId);
            await _carRepository.SaveChangesAsync();
        }

        public bool IsCarInService(int carId)
        {

            return _serviceRepository.GetAllServices().Any(s => s.CarId == carId);
            
        }

        public async Task<bool> IsCarWithoutOwner(int carId)
        {
            var car = await _carRepository.GetCarByIdAsync(carId);

            if (car.OwnerId == null) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
