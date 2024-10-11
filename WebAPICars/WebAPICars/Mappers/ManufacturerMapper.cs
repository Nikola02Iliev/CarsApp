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
                Cars = manufacturerModel.Cars
            };

        }

        public static Manufacturer ToManufacturerModelFromPost(this ManufacturerPostDTO manufacturerPostDTO)
        {
            return new Manufacturer
            {
                ManufacturerName = manufacturerPostDTO.ManufacturerName,
                Country = manufacturerPostDTO.Country,
                EstablishedYear = manufacturerPostDTO.EstablishedYear
            };
        }

        public static Manufacturer ToManufacturerModelFromPut(this ManufacturerPutDTO manufacturerPutDTO)
        {
            return new Manufacturer
            {
                ManufacturerName = manufacturerPutDTO.ManufacturerName,
                Country = manufacturerPutDTO.Country,
                EstablishedYear = manufacturerPutDTO.EstablishedYear
            };
        }
    }
}