using WebAPICars.Models;

namespace WebAPICars.DTOs.ManufacturerDTOs
{
    public class ManufacturerListDTO
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int EstablishedYear { get; set; }
    }
}
