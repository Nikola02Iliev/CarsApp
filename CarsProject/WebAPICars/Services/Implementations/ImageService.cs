using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly ICarRepository _carRepository;

        public ImageService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task SaveImageAsync(CarPostDTO carPostDTO, Car carModel)
        {
            if (carPostDTO.Image != null)
            {
                var imageFileName = $"{Guid.NewGuid()}_{carPostDTO.Image.FileName}";
                var imagesFolderPath = Path.Combine("Images");

                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                var imagePath = Path.Combine(imagesFolderPath, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await carPostDTO.Image.CopyToAsync(stream);
                }

                carModel.ImagePath = imagePath;
            }
        }

        public void DeleteImage(Car car)
        {
            var imagePath = car.ImagePath;
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
           
        }

        public void DeleteImages(IEnumerable<Car> cars)
        {
            foreach (var car in cars) 
            {
                var imagePath = car.ImagePath;
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
        }

        public void DeleteImagesAfterDeletionOfManufacturers(IEnumerable<Manufacturer> manufacturers)
        {
            foreach(var manufacturer in manufacturers)
            {
                var cars = _carRepository.GetAllCars().Where(c => c.ManufacturerId == manufacturer.ManufacturerId).AsEnumerable();

                foreach (var car in cars)
                {
                    var imagePath = car.ImagePath;
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                
            }
        }

        public async Task UpdateImageAsync(CarPutDTO carPutDTO, Car carModel)
        {
           var oldImagePath = carModel.ImagePath;
           if (File.Exists(oldImagePath))
           {
                File.Delete(oldImagePath);
           }

            var imageFileName = $"{Guid.NewGuid()}_{carPutDTO.Image?.FileName}";
            var imagesFolderPath = Path.Combine("Images");

            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            var imagePath = Path.Combine(imagesFolderPath, imageFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await carPutDTO.Image.CopyToAsync(stream);
            }

            carModel.ImagePath = imagePath;
        }

        
    }
}
