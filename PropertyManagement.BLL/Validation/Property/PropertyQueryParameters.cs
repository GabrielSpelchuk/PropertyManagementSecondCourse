namespace PropertyManagement.BLL.Validation.Property
{
    public class PropertyQueryParameters
    {
        public string? Keyword { get; set; }
        public int? PropertyTypeId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SortBy { get; set; } = "price";
        public bool SortDescending { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
