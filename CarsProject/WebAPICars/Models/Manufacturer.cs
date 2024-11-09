using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int? EstablishedYear { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
        
    }
}
