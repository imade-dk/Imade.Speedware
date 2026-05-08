namespace Imade.Speedware.Api.Models;

public partial class News
{
    public int NewsId { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool HasPicture { get; set; }
    public IEnumerable<Blob> Blobs { get; set; } = [];
    public Blob? Blob { get; set; }

}
