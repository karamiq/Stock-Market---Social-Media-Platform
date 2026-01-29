namespace api.Helpers
{
    public class QueryObject
    {
        public string? symbol { get; set; } = null;
        public string? companyName { get; set; } = null;
        public string? sortBy { get; set; } = null;
        public bool isDecending { get; set; } = false;
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 5;
    }
}