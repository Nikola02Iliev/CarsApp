namespace WebAPICars.DTOs.CarDTOs
{
    public class CarListDTOInManufacturer
    {
        public int CarId { get; set; }
        public string Model { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
