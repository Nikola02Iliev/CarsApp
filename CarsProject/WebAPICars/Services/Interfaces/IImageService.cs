using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.Services.Interfaces
{
    public interface IImageService
    {
        Task SaveImageAsync(CarPostDTO carPostDTO, Car carModel);
        void DeleteImage(Car car);
        void DeleteImages(IEnumerable<Car> cars);
        void DeleteImagesAfterDeletionOfManufacturers(IEnumerable<Manufacturer> manufacturers);
        Task UpdateImageAsync(CarPutDTO carPutDTO, Car carModel);

    }
}
