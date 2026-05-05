using Imade.Speedadmin.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models
{
    public class News: SpeedwareViewModels.NewsViewModel, ISpeedwareModel, IBlob, IBlobs
    {

        public List<Blob> Images
        {
            get
            {
                return this.Blobs.Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Images" && x.Size > 0).ToList();
            }
        }
        public List<Blob> Files
        {
            get
            {
                return this.Blobs.Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Files" && x.Size > 0).ToList();
            }
        }

        public List<Blob> Audio
        {
            get
            {
                return this.Blobs.Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Audio" && x.Size > 0).ToList();
            }
        }

        public List<Blob> Video
        {
            get
            {
                return this.Blobs.Where(x => Core.FilesAndPath.FileTypeName(x.MimeType) == "Video" && x.Size > 0).ToList();
            }
        }
    }
}
