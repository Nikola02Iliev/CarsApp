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
                LicensePlate = carModel.LicensePlate
            
            };
        }

        public static CarListDTOInManufacturer ToCarListDTOInManufacturer(this Car carModel) 
        {
            return new CarListDTOInManufacturer
            {
                CarId = carModel.CarId,
                Model = carModel.Model,
                LicensePlate = carModel.LicensePlate
            };
        }
        public static CarListDTOInOwner ToCarListDTOInOwner(this Car carModel)
        {
            return new CarListDTOInOwner
            {
                CarId = carModel.CarId,
                Model = carModel.Model,
                LicensePlate = carModel.LicensePlate,
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
                Manufacturer = carModel.Manufacturer.ToManufacturerGetDTOInCar(),
                Owner = carModel.Owner
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

        public static Car ToCarModel(this CarPostDTO carPostDTO) 
        {
            return new Car
            {
                Model = carPostDTO.Model,
                Price = carPostDTO.Price,
                Year = carPostDTO.Year,
                Color = carPostDTO.Color,
                LicensePlate = carPostDTO.LicensePlate
            };
        }

        public static Car ToCarModelFromPut(this CarPutDTO carPutDTO)
        {
            return new Car
            {
                Model = carPutDTO.Model,
                Price = carPutDTO.Price,
                Year = carPutDTO.Year,
                Color = carPutDTO.Color,
                LicensePlate = carPutDTO.LicensePlate
            };
        }
    }
}
