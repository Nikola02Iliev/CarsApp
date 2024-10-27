using System.ComponentModel;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServicePutDTOForIsCarRepaired
    {
        [DefaultValue(false)]
        public bool IsCarRepaired { get; set; }
    }
}
