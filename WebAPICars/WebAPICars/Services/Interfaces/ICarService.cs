using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.Services.Interfaces
{
    public interface ICarService
    {
        IQueryable<Car> GetAllCars();

        Task<Car> GetCarByIdAsync(int? id);
        Task PostCarAsync(Car car, int? manufacturerId);
        Task PutCar(Car car, CarPutDTO  carPutDTO);
        Task DeleteCar(Car car);
        bool LicensePlateExists(string licensePlate);

    }
}
