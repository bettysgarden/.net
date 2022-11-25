namespace Otvetmailru.WebAPI.Models;

public class PageResponse<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
}