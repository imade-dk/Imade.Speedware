namespace Imade.Speedware.Api.Models;

public class PagedResult<T>
{
    public int TotalResults { get; set; }
    public int RequestResults { get; set; }
    public List<T> Results { get; set; } = [];
}
