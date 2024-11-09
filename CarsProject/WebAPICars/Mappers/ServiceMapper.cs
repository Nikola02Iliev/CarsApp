using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;

namespace WebAPICars.Mappers
{
    public static class ServiceMapper
    {
        public static ServiceListDTO ToServiceListDTO(this Service serviceModel)
        {
            return new ServiceListDTO 
            {
                ServiceId = serviceModel.ServiceId,
                CarId = serviceModel.CarId,
                StartServiceDate = serviceModel.StartServiceDate.ToString("yyyy-MM-dd"),
                EndServiceDate = serviceModel.EndServiceDate.ToString("yyyy-MM-dd"),
                ServiceType = serviceModel.ServiceType,
                Cost = serviceModel.Cost,
                IsCarRepaired = serviceModel.IsCarRepaired
            };
        }

        public static ServiceGetDTO ToServiceGetDTO(this Service serviceModel) 
        {
            return new ServiceGetDTO 
            {
                ServiceId = serviceModel.ServiceId,
                CarId = serviceModel.CarId,
                StartServiceDate = serviceModel.StartServiceDate.ToString("yyyy-MM-dd"),
                EndServiceDate = serviceModel.EndServiceDate.ToString("yyyy-MM-dd"),
                ServiceType = serviceModel.ServiceType,
                ServiceDescription = serviceModel.ServiceDescription,
                Cost = serviceModel.Cost,
                IsCarRepaired = serviceModel.IsCarRepaired,
                Car = serviceModel.Car.ToCarGetDTOInService()
               
            };
        }

        public static ServiceGetDTOAfterPost ToServiceGetDTOAfterPost(this Service serviceModel)
        {
            return new ServiceGetDTOAfterPost
            {
                ServiceId = serviceModel.ServiceId,
                CarId = serviceModel.CarId,
                StartServiceDate = serviceModel.StartServiceDate.ToString("yyyy-MM-dd"),
                EndServiceDate = serviceModel.EndServiceDate.ToString("yyyy-MM-dd"),
                ServiceType = serviceModel.ServiceType,
                ServiceDescription = serviceModel.ServiceDescription,
                Cost = serviceModel.Cost,
                IsCarRepaired = serviceModel.IsCarRepaired,
                Car = serviceModel.Car.ToCarGetDTOInServiceAfterPost()


            };
        }

        public static Service ToServiceModel(this ServicePostDTO servicePostDTO) 
        {
            return new Service
            {
                StartServiceDate = DateTime.Parse(servicePostDTO.StartServiceDate),
                EndServiceDate = DateTime.Parse(servicePostDTO.EndServiceDate),
                ServiceType = servicePostDTO.ServiceType,
                ServiceDescription = servicePostDTO.ServiceDescription,
                Cost = servicePostDTO.Cost,
            };
        }

        
    }
}
