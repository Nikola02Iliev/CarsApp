using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;

namespace WebAPICars.Services.Interfaces
{
    public interface IServiceService
    {
        IQueryable<Service> GetAllServices();
        Task<Service> GetServiceByIdAsync(int? id);
        Task PostServiceAsync(Service service, int carId);
        Task PutService(Service service, ServicePutDTO servicePutDTO);
        Task DeleteService(Service service);
    }
}
