using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.Repositories.Interfaces
{
    public interface ICarRepository
    {
        IQueryable<Car> GetAllCars();
        Task<Car> GetCarByIdAsync(int? id);
        Task PostCarAsync(Car car);
        void PutCar(Car car, CarPutDTO carPutDTO);
        void PutCarOwnerId(Car car, int? ownerId);
        void DeleteCar(Car car);
        void DeleteCars(IEnumerable<Car> cars);
        Task SaveChangesAsync();

    }
}
