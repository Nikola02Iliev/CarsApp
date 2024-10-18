namespace WebAPICars.Filters
{
    public class ManufacturerQueries
    {
        public string ManufacturerName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int? EstablishedYear { get; set; }
        public string SortBy {  get; set; } = string.Empty;
        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
