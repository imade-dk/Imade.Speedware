using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;


public partial class Booking :  ISpeedwareModel, IBlobs
{
    public Blob? Blob
    {
        get
        {
            return Blobs?.FirstOrDefault() ?? null;
        }
    }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsAllDayEvent { get; set; } = false;
    public string? Location { get; set; }
    public string? LinkName { get; set; }
    public string? LinkTarget { get; set; }
    public string? LinkUrl { get; set; }
    public string? Text { get; set; }
}
