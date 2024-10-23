namespace WebAPICars.DTOs.OwnerDTOs
{
    public class OwnerGetDTOInCar
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
