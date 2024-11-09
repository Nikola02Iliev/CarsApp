using WebAPICars.DTOs.OwnerDTOs;

namespace WebAPICars.DTOs.CarDTOs
{
    public class CarGetDTOInServiceAfterPost
    {

        public int CarId { get; set; }
        public string Model { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;

        public OwnerGetDTOInCarGetDTOInServiceAfterPost? Owner { get; set; }
    }
}
