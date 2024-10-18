using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICars.Queries
{
    public class CarQueries
    {
        public string Model { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public string SortBy {  get; set; } = string.Empty;
        public bool IsDescending {  get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
