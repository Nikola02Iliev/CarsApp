using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;

namespace WebAPICars.DTOs.CarDTOs
{
    public class CarGetDTOInService
    {
        public int CarId { get; set; }
        public string Model { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public OwnerGetDTOInCarGetDTOInService? Owner { get; set; }
    }
}
