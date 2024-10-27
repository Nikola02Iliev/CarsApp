using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICars.Queries
{
    public class ServiceQueries
    {
        public string StartServiceDate { get; set; } = string.Empty;
        public string  EndServiceDate { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public decimal? Cost { get; set; }
        public string SortBy { get; set; } = string.Empty;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
