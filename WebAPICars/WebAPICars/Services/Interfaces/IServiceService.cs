using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;

namespace WebAPICars.Services.Interfaces
{
    public interface IServiceService
    {
        IQueryable<Service> GetAllServices(ServiceQueries serviceQueries);
        IQueryable<Service> GetAllServicesWithRepairedCars(ServiceQueries serviceQueries);
        IQueryable<Service> GetAllServicesWithNotRepairedCars(ServiceQueries serviceQueries);
        Task<Service> GetServiceByIdAsync(int? id);
        Task PostServiceAsync(Service service, int carId);
        Task PutService(Service service, ServicePutDTO servicePutDTO);
        Task PutServiceIsCarRepairedToTrue(Service service);
        Task DeleteService(Service service);
    }
}
