using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.DTOs.OwnerDTOs
{
    public class OwnerGetDTO
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<CarListDTOInOwner> Cars { get; set; } = new List<CarListDTOInOwner>();
    }
}
