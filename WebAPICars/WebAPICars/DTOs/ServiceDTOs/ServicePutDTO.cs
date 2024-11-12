using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.Service;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServicePutDTO
    {

        [DataType(DataType.Date)]
        [ValidationsForEndServiceDateForPut]
        public string EndServiceDate { get; set; } = string.Empty;

        [ValidationsForServiceType]
        public string ServiceType { get; set; } = string.Empty;

        [ValidationsForServiceDescription]
        public string ServiceDescription { get; set; } = string.Empty;

        [ValidationsForCost]
        public decimal? Cost { get; set; }



    }
}
