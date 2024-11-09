using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.Mappers
{
    public static class CarMapper
    {
        public static CarListDTO ToCarListDTO(this Car carModel)
        {
            return new CarListDTO 
            {
                CarId = carModel.CarId,
                ManufacturerId = carModel.ManufacturerId,
                OwnerId = carModel.OwnerId,
                Model = carModel.Model,
                Price = carModel.Price,
                Year = carModel.Year,
                Color = carModel.Color,
                LicensePlate = carModel.LicensePlate,
                ImagePath = carModel.ImagePath
            
            };
        }

        public static CarListDTOInManufacturer ToCarListDTOInManufacturer(this Car carModel) 
        {
            return new CarListDTOInManufacturer
            {
                CarId = carModel.CarId,
                Model = carModel.Model,
                LicensePlate = carModel.LicensePlate,
                ImagePath = carModel.ImagePath
            };
        }
        public static CarListDTOInOwner ToCarListDTOInOwner(this Car carModel)
        {
            return new CarListDTOInOwner
            {
                CarId = carModel.CarId,
                Model = carModel.Model,
                LicensePlate = carModel.LicensePlate,
                ImagePath = carModel.ImagePath,
                Manufacturer = carModel.Manufacturer.ToManufacturerDTOInCarListDTOInOwner()
            };
        }

        public static CarGetDTO ToCarGetDTO(this Car carModel) 
        {
            return new CarGetDTO
            {
                CarId = carModel.CarId,
                ManufacturerId = carModel.ManufacturerId,
                OwnerId = carModel.OwnerId,
                Model = carModel.Model,
                Price = carModel.Price,
                Year = carModel.Year,
                Color = carModel.Color,
                LicensePlate = carModel.LicensePlate,
                ImagePath = carModel.ImagePath,
                Manufacturer = carModel.Manufacturer.ToManufacturerGetDTOInCar(),
                Owner = carModel.Owner.ToOwnerGetDTOInCar()
            };
        }

        public static CarGetDTOAfterPost ToCarGetDTOAfterPost(this Car carModel)
        {
            return new CarGetDTOAfterPost
            {
                CarId = carModel.CarId,
                ManufacturerId = carModel.ManufacturerId,
                OwnerId = carModel.OwnerId,
                Model = carModel.Model,
                Price = carModel.Price,
                Year = carModel.Year,
                Color = carModel.Color,
                LicensePlate = carModel.LicensePlate
            };
        }

        public static CarGetDTOInService ToCarGetDTOInService(this Car carModel)
        {
            return new CarGetDTOInService
            {
                CarId = carModel.CarId,
                Model = carModel.Model,
                LicensePlate = carModel.LicensePlate,
                ImagePath= carModel.ImagePath,
                Owner = carModel.Owner.ToOwnerGetDTOInCarGetDTOInService()
            };
        }

        public static CarGetDTOInServiceAfterPost ToCarGetDTOInServiceAfterPost(this Car carModel)
        {
            return new CarGetDTOInServiceAfterPost
            {
                CarId = carModel.CarId,
                Model = carModel.Model,
                LicensePlate = carModel.LicensePlate,
                Owner = carModel.Owner.ToOwnerGetDTOInCarGetDTOInServiceAfterPost()
            };
        }


        public static Car ToCarModel(this CarPostDTO carPostDTO) 
        {
            return new Car
            {
                Model = carPostDTO.Model,
                Price = carPostDTO.Price,
                Year = carPostDTO.Year,
                Color = carPostDTO.Color,
                LicensePlate = carPostDTO.LicensePlate,
                ImagePath = carPostDTO.Image.ToString(),
            };
        }
    }
}
