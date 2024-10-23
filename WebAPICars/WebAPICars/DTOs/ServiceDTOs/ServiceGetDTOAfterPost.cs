using System.ComponentModel.DataAnnotations.Schema;
using WebAPICars.DTOs.CarDTOs;
using WebAPICars.Models;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServiceGetDTOAfterPost
    {
        public int ServiceId { get; set; }
        public int? CarId { get; set; }
        public string StartServiceDate { get; set; } = string.Empty;
        public string EndServiceDate { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        public bool IsCarRepaired { get; set; }

        public CarGetDTOInServiceAfterPost? Car {  get; set; }
    }
}
