using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
    [Serializable]
    public abstract class BlobViewModel
    {
        public string BlobId { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public string Extention { get; set; }
        public int UniqueId { get; set; }
    }
}

