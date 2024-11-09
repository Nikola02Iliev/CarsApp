using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.Manufacturer;

namespace WebAPICars.DTOs.ManufacturerDTOs
{
    public class ManufacturerPutDTO
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field can't be more than 50 characters")]
        [ValidationForManufacturerName]
        public string ManufacturerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field can't be more than 50 characters")]
        public string Country { get; set; } = string.Empty;

        [ValidationForEstablishedYear]
        public int? EstablishedYear { get; set; }

    }
}
