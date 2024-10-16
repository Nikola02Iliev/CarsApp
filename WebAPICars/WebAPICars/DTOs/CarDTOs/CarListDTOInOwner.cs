using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.Models;

namespace WebAPICars.DTOs.CarDTOs
{
    public class CarListDTOInOwner
    {
        public int CarId { get; set; }
        public string Model { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public ManufacturerDTOInCarListDTOInOwner? Manufacturer { get; set; }
    }
}
