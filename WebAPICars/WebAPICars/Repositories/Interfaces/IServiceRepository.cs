using Newtonsoft.Json.Bson;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;

namespace WebAPICars.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        IQueryable<Service> GetAllServices();
        Task<Service> GetServiceByIdAsync(int? id);
        Task PostServiceAsync(Service service);
        void PutService(Service service, ServicePutDTO servicePutDTO);
        void DeleteService(Service service);
        Task SaveChangesAsync();       
    }
}
