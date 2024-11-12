using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.CarDTOs;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;

namespace WebAPICars.Repositories.Implementations
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Car> _dbSet;

        public CarRepository(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Car>();
        }

        public IQueryable<Car> GetAllCars()
        {
            var cars = _dbSet.AsQueryable();

            return cars;
        }

        public async Task<Car> GetCarByIdAsync(int? id)
        {
            var car = await _dbSet
                .Include(c => c.Manufacturer)
                .Include(c => c.Owner)
                .SingleOrDefaultAsync(c => c.CarId == id);

            return car;
        }

        public async Task PostCarAsync(Car car)
        {
            await _dbSet.AddAsync(car);
        }

        public void PutCar(Car car, CarPutDTO carPutDTO)
        {
            car.Model = carPutDTO.Model;
            car.Price = carPutDTO.Price;
            car.Year = carPutDTO.Year;
            car.Color = carPutDTO.Color;
            car.LicensePlate = carPutDTO.LicensePlate;
            car.RowVersion = carPutDTO.RowVersion;
        }

        public void PutCarOwnerId(Car car, int? ownerId)
        {
            car.OwnerId = ownerId;
        }

        public void DeleteCar(Car car)
        {
            _dbSet.Remove(car);  
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void DeleteCars(IEnumerable<Car> cars)
        {
            _dbSet.RemoveRange(cars);
        }

        
    }
}
