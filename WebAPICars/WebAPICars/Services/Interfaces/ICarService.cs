using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;

namespace WebAPICars.Services.Interfaces
{
    public interface ICarService
    {
        IQueryable<Car> GetAllCars(CarQueries carQueries);

        Task<Car> GetCarByIdAsync(int? id);
        Task PostCarAsync(Car car, int? manufacturerId, int? ownerId);
        Task PutCar(Car car, CarPutDTO  carPutDTO);
        Task DeleteCar(Car car);
        bool LicensePlateExists(string licensePlate);

    }
}
