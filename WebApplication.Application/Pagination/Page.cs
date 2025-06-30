using System.Text.Json.Serialization;

namespace WebApplication.Application.Pagination
{
    public class Page<T>
    {
        public int PageIndex { get; }

        public IEnumerable<T> Items { get; }

        public int Count { get; }

        public int Total { get; }

        [JsonConstructor]
        public Page(IEnumerable<T> items, int pageIndex, int total, int count)
        {
            Items = items;
            PageIndex = pageIndex;
            Total = total;
            Count = count;
        }
    }
}
