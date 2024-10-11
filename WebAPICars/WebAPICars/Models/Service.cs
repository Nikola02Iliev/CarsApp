using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICars.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int? CarId {  get; set; }
        public DateTime StartServiceDate { get; set; }
        public DateTime EndServiceDate { get; set;}
        public string ServiceName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost {  get; set; }
        public Car? Car { get; set; }

    }
}
