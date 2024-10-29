using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;

namespace WebAPICars.Services.Interfaces
{
    public interface ICarService
    {
        IQueryable<Car> GetAllCars(CarQueries carQueries);
        IQueryable<Car> GetCarsWithoutOwner(CarQueries carQueries);
        IEnumerable<Car> GetAllCarsForDeletion();
        Task<Car> GetCarByIdAsync(int? id);
        Task PostCarAsync(Car car, int? manufacturerId, int? ownerId);
        Task PostCarWithoutOwnerAsync(Car car, int? manufacturerId);
        Task PutCar(Car car, CarPutDTO  carPutDTO);
        Task PutCarOwnerId(Car car, int? ownerId);
        Task DeleteCar(Car car);
        Task DeleteAllCars(IEnumerable<Car> cars);
        bool LicensePlateExists(string licensePlate);
        bool IsCarInService(int carId);
        Task<bool> IsCarWithoutOwner(int carId);

    }
}
