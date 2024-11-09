using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.Owner;

namespace WebAPICars.DTOs.OwnerDTOs
{
    public class OwnerPostDTO
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field can't be more than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field can't be more than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [ValidationForAge]
        public int? Age { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, ErrorMessage = "This field can't be more than 255 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(12, ErrorMessage = "This field can't be more than 12 characters")]
        [ValidationForPhoneNumber]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "This field can't be more than 50 characters")]
        [ValidationForEmail]
        public string Email { get; set; } = string.Empty;
    }
}
