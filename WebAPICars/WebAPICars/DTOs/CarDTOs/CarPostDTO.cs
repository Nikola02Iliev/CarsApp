using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPICars.Validations.Car;

namespace WebAPICars.DTOs.CarDTOs
{
    public class CarPostDTO
    {
        [ValidationsForModel]
        public string Model { get; set; } = string.Empty;

        [ValidationsForPrice]
        public decimal? Price { get; set; }

        [ValidationsForYear]
        public int? Year { get; set; }

        [ValidationsForColor]
        public string Color { get; set; } = string.Empty;


        [ValidationsForLicensePlate]
        public string LicensePlate { get; set; } = string.Empty;

        [ValidationsForImage]
        public IFormFile? Image { get; set; }
    }
}
