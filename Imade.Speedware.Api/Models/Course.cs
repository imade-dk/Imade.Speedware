using Imade.Speedware.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
    public class Course : SpeedwareViewModels.CourseViewModel, ISpeedwareModel, IBlobs
    {
        public int TreeId { get; set; }

        public string Title { get { return Course; } }

        public Blob Blob
        {
            get
            {
                return Blobs.FirstOrDefault();
            }
        }
        public List<Teacher> Teachers { get; set; } = new();
        public List<School> Schools { get; set; } = new();
    }
}
