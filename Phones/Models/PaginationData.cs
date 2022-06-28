namespace Phones.Models
{
    public class PaginationData<T>
    {
        public List<T> Items { get; set; }
        public int TotalPageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }
       
        public int CurrentPage { get; set; }

        public PaginationData(List<T> items, int totalItemCount, int pageSize, int currentPage)
        {
            Items = items;
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }
    }
}
