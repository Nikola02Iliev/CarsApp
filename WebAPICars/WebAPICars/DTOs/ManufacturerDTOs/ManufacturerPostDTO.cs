using WebAPICars.Validations.Manufacturer;

namespace WebAPICars.DTOs.ManufacturerDTOs
{
    public class ManufacturerPostDTO
    {
        [ValidationsForManufacturerName]
        public string ManufacturerName { get; set; } = string.Empty;

        [ValidationsForCountry]
        public string Country { get; set; } = string.Empty;

        [ValidationsForEstablishedYear]
        public int? EstablishedYear { get; set; }
    }
}
