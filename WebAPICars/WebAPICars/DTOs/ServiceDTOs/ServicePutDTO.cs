using System.ComponentModel;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServicePutDTO
    {
        [DefaultValue("yyyy-MM-dd")]
        public string EndServiceDate { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public decimal Cost { get; set; }

        [DefaultValue(false)]
        public bool IsCarRepaired { get; set; }

    }
}
