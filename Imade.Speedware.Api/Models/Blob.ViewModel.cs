namespace Imade.Speedware.Api.Models;


public partial class Blob
{
    public string? BlobId { get; set; }
    public string? Name { get; set; }
    public string? MimeType { get; set; }
    public int Size { get; set; }
    public string? Extention { get; set; }
    public int UniqueId { get; set; }
}

