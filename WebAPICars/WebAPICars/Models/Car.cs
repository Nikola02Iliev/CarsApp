using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WebAPICars.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? OwnerId { get; set; }
        public string Model { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Color {  get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public Manufacturer? Manufacturer { get; set; }
        public Owner? Owner { get; set; }
    }
}
