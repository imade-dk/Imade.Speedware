using Imade.Speedware.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
    [Serializable]
    public class Booking : SpeedwareViewModels.BookingViewModel, ISpeedwareModel, IBlobs
    {
        public Blob Blob
        {
            get
            {
                return Blobs?.FirstOrDefault() ?? null;
            }
        }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsAllDayEvent { get; set; } = false;
        public string Location { get; set; }
        public string LinkName { get; set; }
        public string LinkTarget { get; set; }
        public string LinkUrl { get; set; }
        public string Text { get; set; }
    }
}
