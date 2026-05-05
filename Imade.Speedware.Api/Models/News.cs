using Imade.Speedware.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
    public class News: SpeedwareViewModels.NewsViewModel, ISpeedwareModel, IBlob, IBlobs
    {

        public List<Blob> Images =>
            (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Images" && x.Size > 0).ToList();

        public List<Blob> Files =>
            (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Files" && x.Size > 0).ToList();

        public List<Blob> Audio =>
            (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Audio" && x.Size > 0).ToList();

        public List<Blob> Video =>
            (Blobs ?? []).Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Video" && x.Size > 0).ToList();
    }
}
