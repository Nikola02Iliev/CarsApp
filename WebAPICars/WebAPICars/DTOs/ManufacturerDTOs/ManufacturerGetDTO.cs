using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.DTOs.ManufacturerDTOs
{
    public class ManufacturerGetDTO
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int EstablishedYear { get; set; }
        public List<CarListDTOInManufacturer> Cars { get; set; } = new List<CarListDTOInManufacturer>();
    }
}
