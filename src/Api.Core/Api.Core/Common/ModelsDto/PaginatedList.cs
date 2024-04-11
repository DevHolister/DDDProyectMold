namespace Api.Core.Common.ModelsDto;

public class PaginatedList<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get => ComputeTotalPages(); }
    public int Total { get; set; }

    public PaginatedList(IEnumerable<T> items, int count, int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
        Total = count;
        Items = items;
    }

    private int ComputeTotalPages()
    {
        if (PageSize > 0)
        {
            return (int)Math.Ceiling(Total / (double)PageSize);
        }
        return 1;
    }
}
