namespace WebAPICars.DTOs.ManufacturerDTOs
{
    public class ManufacturerPutDTO
    {
        public string ManufacturerName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int EstablishedYear { get; set; }

    }
}
