using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Api.Interfaces;

public interface IBlobs
{
    public IEnumerable<Blob> Blobs { get; set; }
}
