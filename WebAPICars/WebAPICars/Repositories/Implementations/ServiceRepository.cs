using Microsoft.EntityFrameworkCore;
using WebAPICars.Context;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;

namespace WebAPICars.Repositories.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDBContext _context;
        private readonly DbSet<Service> _dbSet;

        public ServiceRepository(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<Service>();
        }

        public IQueryable<Service> GetAllServices()
        {
            var services = _dbSet.AsQueryable();

            return services;
        }

        public async Task<Service> GetServiceByIdAsync(int? id)
        {
            var service = await _dbSet
                .Include(s => s.Car)
                    .ThenInclude(c => c.Owner)
                .SingleOrDefaultAsync(s => s.ServiceId == id);

            return service;
        }

        public async Task PostServiceAsync(Service service)
        {
            await _dbSet.AddAsync(service);
        }

        public void PutService(Service service, ServicePutDTO servicePutDTO)
        {
            service.EndServiceDate = DateTime.Parse(servicePutDTO.EndServiceDate);
            service.ServiceType = servicePutDTO.ServiceType;
            service.ServiceDescription = servicePutDTO.ServiceDescription;
            service.Cost = servicePutDTO.Cost;
        }

        public void PutServiceIsCarRepairedToTrue(Service service)
        {
            service.IsCarRepaired = true;
           
        }

        public void DeleteService(Service service)
        {
            _dbSet.Remove(service);
        }

        public void DeleteAllServices(IEnumerable<Service> services)
        {
            _dbSet.RemoveRange(services);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
