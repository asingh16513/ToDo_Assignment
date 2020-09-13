namespace Domain.Models
{
    public class SearchFilter
    {
        public string SearchString { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
