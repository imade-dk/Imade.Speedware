using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;

public partial class Course : ISpeedwareModel, IBlobs
{
    public int TreeId { get; set; }

    public string? Title { get { return Name; } }

    public Blob? Blob
    {
        get
        {
            return Blobs.FirstOrDefault();
        }
    }
    public List<Teacher> Teachers { get; set; } = [];
    public List<School> Schools { get; set; } = [];
}
