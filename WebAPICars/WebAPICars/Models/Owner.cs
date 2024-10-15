using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new List<Car>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
