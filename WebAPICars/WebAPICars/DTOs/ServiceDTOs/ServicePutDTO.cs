using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.Service;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServicePutDTO
    {

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        [ValidationForEndServiceDateForPut]
        public string EndServiceDate { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(30, ErrorMessage = "This field can't be more than 30 characters")]
        public string ServiceType { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, ErrorMessage = "This field can't be more than 255 characters")]
        public string ServiceDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [ValidationForCost]
        public decimal Cost { get; set; }


    }
}
