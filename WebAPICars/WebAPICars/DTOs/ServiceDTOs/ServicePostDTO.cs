using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.Service;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServicePostDTO
    {
        [ValidationsForStartServiceDate]
        [DataType(DataType.Date)]
        public string StartServiceDate { get; set; } = string.Empty;

        [ValidationsForEndServiceDateForPost]
        [DataType(DataType.Date)]
        public string EndServiceDate { get; set; } = string.Empty;

        [ValidationsForServiceType]
        public string ServiceType { get; set; } = string.Empty;

        [ValidationsForServiceDescription]
        public string ServiceDescription { get; set; } = string.Empty;

        [ValidationsForCost]
        public decimal? Cost { get; set; }

    }
}
