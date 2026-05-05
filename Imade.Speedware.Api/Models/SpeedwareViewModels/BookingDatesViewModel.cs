using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
    [Serializable]
    public abstract class BookingDatesViewModel
    {
        public int BookingDateId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
    }
}
