using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;

public partial class News:  ISpeedwareModel, IBlob, IBlobs
{

    public List<Blob> Images =>
        [.. (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType ?? string.Empty) == "Images" && x.Size > 0)];

    public List<Blob> Files =>
        [.. (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType ?? string.Empty) == "Files" && x.Size > 0)];

    public List<Blob> Audio =>
        [.. (Blobs ?? []).Where(static x => Core.FilesAndPath.FileTypeName(x.MimeType ?? string.Empty) == "Audio" && x.Size > 0)];

    public List<Blob> Video =>
        [.. (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType ?? string.Empty) == "Video" && x.Size > 0)];
}
