using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            HasNext = pageNumber * pageSize < count;
            HasPrevious = pageNumber > 1;
            AddRange(items);
        }

        public bool HasNext { get; private set; }
        public bool HasPrevious { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
