using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICars.DTOs.CarDTOs
{
    public class CarGetDTOAfterPost
    {
        public int CarId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? OwnerId { get; set; }
        public string Model { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
    }
}
