using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        
        public IQueryable<Car> GetAllCars()
        {
            var cars = _carRepository.GetAllCars();

            return cars;
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
    }
}
