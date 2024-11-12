using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.Owner;

namespace WebAPICars.DTOs.OwnerDTOs
{
    public class OwnerPostDTO
    {
        [ValidationsForFirstName]
        public string FirstName { get; set; } = string.Empty;

        [ValidationsForLastName]
        public string LastName { get; set; } = string.Empty;

        [ValidationsForAge]
        public int? Age { get; set; }

        [ValidationsForAddress]
        public string Address { get; set; } = string.Empty;

        [ValidationsForPhoneNumber]
        public string PhoneNumber { get; set; } = string.Empty;

        [ValidationsForEmail]
        public string Email { get; set; } = string.Empty;
    }
}
