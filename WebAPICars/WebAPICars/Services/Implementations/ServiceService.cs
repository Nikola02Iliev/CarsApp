using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ICarRepository _carRepository;

        public ServiceService(IServiceRepository serviceRepository, ICarRepository carRepository)
        {
            _serviceRepository = serviceRepository;
            _carRepository = carRepository;
        }

        public IQueryable<Service> GetAllServices()
        {
            var services = _serviceRepository.GetAllServices();

            return services;
        }

        public async Task<Service> GetServiceByIdAsync(int? id)
        {
            var service = await _serviceRepository.GetServiceByIdAsync(id);

            return service;
        }

        public async Task PostServiceAsync(Service service, int carId)
        {
            var car = await _carRepository.GetCarByIdAsync(carId);

            service.CarId = carId;
            service.Car = car;

            await _serviceRepository.PostServiceAsync(service);
            await _serviceRepository.SaveChangesAsync();
        }

        public async Task PutService(Service service, ServicePutDTO servicePutDTO)
        {
            _serviceRepository.PutService(service, servicePutDTO);
            await _serviceRepository.SaveChangesAsync();
        }

        public async Task DeleteService(Service service)
        {
            _serviceRepository.DeleteService(service);
            await _serviceRepository.SaveChangesAsync();
        }
    }
}
