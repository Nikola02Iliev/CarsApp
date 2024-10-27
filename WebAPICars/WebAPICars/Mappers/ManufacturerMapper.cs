using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;

namespace WebAPICars.Mappers
{
    public static class ManufacturerMapper
    {
        public static ManufacturerListDTO ToManufacturerListDTO(this Manufacturer manufacturerModel)
        {
            return new ManufacturerListDTO
            {
                ManufacturerId = manufacturerModel.ManufacturerId,
                ManufacturerName = manufacturerModel.ManufacturerName,
                Country = manufacturerModel.Country,
                EstablishedYear = manufacturerModel.EstablishedYear
            };
        }

        public static ManufacturerGetDTO ToManufacturerGetDTO(this Manufacturer manufacturerModel)
        {
            return new ManufacturerGetDTO
            {
                ManufacturerId = manufacturerModel.ManufacturerId,
                ManufacturerName = manufacturerModel.ManufacturerName,
                Country = manufacturerModel.Country,
                EstablishedYear = manufacturerModel.EstablishedYear,
                Cars = manufacturerModel.Cars.Select(c => c.ToCarListDTOInManufacturer()).ToList()
            };

        }

        public static ManufacturerGetDTOAfterPost ToManufacturerGetDTOAfterPost(this Manufacturer manufacturerModel)
        {
            return new ManufacturerGetDTOAfterPost
            {
                ManufacturerId = manufacturerModel.ManufacturerId,
                ManufacturerName = manufacturerModel.ManufacturerName,
                Country = manufacturerModel.Country,
                EstablishedYear = manufacturerModel.EstablishedYear
            };
        }

        public static ManufacturerGetDTOInCar ToManufacturerGetDTOInCar(this Manufacturer manufacturerModel) 
        {
            return new ManufacturerGetDTOInCar
            {
                ManufacturerId = manufacturerModel.ManufacturerId,
                ManufacturerName = manufacturerModel.ManufacturerName
            };
        }

        public static ManufacturerDTOInCarListDTOInOwner ToManufacturerDTOInCarListDTOInOwner(this Manufacturer manufacturerModel)
        {
            return new ManufacturerDTOInCarListDTOInOwner
            {
                ManufacturerId = manufacturerModel.ManufacturerId,
                ManufacturerName = manufacturerModel.ManufacturerName
            };
        }

        public static Manufacturer ToManufacturerModel(this ManufacturerPostDTO manufacturerPostDTO)
        {
            return new Manufacturer
            {
                ManufacturerName = manufacturerPostDTO.ManufacturerName,
                Country = manufacturerPostDTO.Country,
                EstablishedYear = manufacturerPostDTO.EstablishedYear
            };
        }

        
    }
}