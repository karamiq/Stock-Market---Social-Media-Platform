namespace helpers
{
    public class PaginationParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int MaxPageSize { get; set; } = 50;

        public int Skip => (PageNumber - 1) * PageSize;
        public int Take => PageSize > MaxPageSize ? MaxPageSize : PageSize;
    }

    public class PagedResult<T>
    {
        public required IEnumerable<T> Items { get; set; }
        public  int TotalCount { get; set; }
        public  int PageNumber { get; set; }
        public  int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public static class PaginationService
    {
        public static PagedResult<T> CreatePagedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedResult<T>
            {
                Items = items,
                TotalCount = count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}