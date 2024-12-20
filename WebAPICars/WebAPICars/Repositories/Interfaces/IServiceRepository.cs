﻿using Newtonsoft.Json.Bson;
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
        void PutServiceIsCarRepairedToTrue(Service service);
        void DeleteService(Service service);
        void DeleteAllServices(IEnumerable<Service> services);
        Task SaveChangesAsync();       
    }
}
