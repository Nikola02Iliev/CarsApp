using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;
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

        public IQueryable<Service> GetAllServices(ServiceQueries serviceQueries)
        {
            var services = _serviceRepository.GetAllServices();

            if (!string.IsNullOrWhiteSpace(serviceQueries.StartServiceDate))
            {
                services = services.Where(s => s.StartServiceDate == DateTime.Parse(serviceQueries.StartServiceDate));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.EndServiceDate))
            {
                services = services.Where(s => s.EndServiceDate == DateTime.Parse(serviceQueries.EndServiceDate));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.ServiceType))
            {
                services = services.Where(s => s.ServiceType.Contains(serviceQueries.ServiceType));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.ServiceDescription))
            {
                services = services.Where(s => s.ServiceDescription.Contains(serviceQueries.ServiceDescription));
            }

            if(serviceQueries.Cost != null)
            {
                services = services.Where(s => s.Cost == serviceQueries.Cost);
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.SortBy))
            {
                if(serviceQueries.SortBy == "StartServiceDate")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.StartServiceDate);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.StartServiceDate);
                    }
                }

                if (serviceQueries.SortBy == "EndServiceDate")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.EndServiceDate);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.EndServiceDate);
                    }
                }

                if (serviceQueries.SortBy == "ServiceType")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.ServiceType);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.ServiceType);
                    }
                }

                if (serviceQueries.SortBy == "ServiceDescription")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.ServiceDescription);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.ServiceDescription);
                    }
                }

                if (serviceQueries.SortBy == "Cost")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.Cost);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.Cost);
                    }
                }

            }
            
            var skipNumber = (serviceQueries.PageNumber - 1) * serviceQueries.PageSize;
            var takeNumber = serviceQueries.PageSize;

            return services.Skip(skipNumber).Take(takeNumber);
        }

        public IQueryable<Service> GetAllServicesWithRepairedCars(ServiceQueries serviceQueries)
        {
            var services = _serviceRepository.GetAllServices();

            services = services.Where(s => s.IsCarRepaired == true);

            if (!string.IsNullOrWhiteSpace(serviceQueries.StartServiceDate))
            {
                services = services.Where(s => s.StartServiceDate == DateTime.Parse(serviceQueries.StartServiceDate));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.EndServiceDate))
            {
                services = services.Where(s => s.EndServiceDate == DateTime.Parse(serviceQueries.EndServiceDate));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.ServiceType))
            {
                services = services.Where(s => s.ServiceType.Contains(serviceQueries.ServiceType));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.ServiceDescription))
            {
                services = services.Where(s => s.ServiceDescription.Contains(serviceQueries.ServiceDescription));
            }

            if (serviceQueries.Cost != null)
            {
                services = services.Where(s => s.Cost == serviceQueries.Cost);
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.SortBy))
            {
                if (serviceQueries.SortBy == "StartServiceDate")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.StartServiceDate);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.StartServiceDate);
                    }
                }

                if (serviceQueries.SortBy == "EndServiceDate")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.EndServiceDate);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.EndServiceDate);
                    }
                }

                if (serviceQueries.SortBy == "ServiceType")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.ServiceType);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.ServiceType);
                    }
                }

                if (serviceQueries.SortBy == "ServiceDescription")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.ServiceDescription);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.ServiceDescription);
                    }
                }

                if (serviceQueries.SortBy == "Cost")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.Cost);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.Cost);
                    }
                }

            }


            var skipNumber = (serviceQueries.PageNumber - 1) * serviceQueries.PageSize;
            var takeNumber = serviceQueries.PageSize;

            return services.Skip(skipNumber).Take(takeNumber);

        }

        public IQueryable<Service> GetAllServicesWithNotRepairedCars(ServiceQueries serviceQueries)
        {
            var services = _serviceRepository.GetAllServices();

            services = services.Where(s => s.IsCarRepaired == false);

            if (!string.IsNullOrWhiteSpace(serviceQueries.StartServiceDate))
            {
                services = services.Where(s => s.StartServiceDate == DateTime.Parse(serviceQueries.StartServiceDate));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.EndServiceDate))
            {
                services = services.Where(s => s.EndServiceDate == DateTime.Parse(serviceQueries.EndServiceDate));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.ServiceType))
            {
                services = services.Where(s => s.ServiceType.Contains(serviceQueries.ServiceType));
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.ServiceDescription))
            {
                services = services.Where(s => s.ServiceDescription.Contains(serviceQueries.ServiceDescription));
            }

            if (serviceQueries.Cost != null)
            {
                services = services.Where(s => s.Cost == serviceQueries.Cost);
            }

            if (!string.IsNullOrWhiteSpace(serviceQueries.SortBy))
            {
                if (serviceQueries.SortBy == "StartServiceDate")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.StartServiceDate);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.StartServiceDate);
                    }
                }

                if (serviceQueries.SortBy == "EndServiceDate")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.EndServiceDate);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.EndServiceDate);
                    }
                }

                if (serviceQueries.SortBy == "ServiceType")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.ServiceType);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.ServiceType);
                    }
                }

                if (serviceQueries.SortBy == "ServiceDescription")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.ServiceDescription);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.ServiceDescription);
                    }
                }

                if (serviceQueries.SortBy == "Cost")
                {
                    if (serviceQueries.IsDescending)
                    {
                        services = services.OrderByDescending(s => s.Cost);
                    }
                    else
                    {
                        services = services.OrderBy(s => s.Cost);
                    }
                }

            }


            var skipNumber = (serviceQueries.PageNumber - 1) * serviceQueries.PageSize;
            var takeNumber = serviceQueries.PageSize;

            return services.Skip(skipNumber).Take(takeNumber);
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

        public async Task PutServiceIsCarRepairedToTrue(Service service)
        {
            _serviceRepository.PutServiceIsCarRepairedToTrue(service);
            await _serviceRepository.SaveChangesAsync();
        }


        public async Task DeleteService(Service service)
        {
            _serviceRepository.DeleteService(service);
            await _serviceRepository.SaveChangesAsync();
        }

        
    }
}
