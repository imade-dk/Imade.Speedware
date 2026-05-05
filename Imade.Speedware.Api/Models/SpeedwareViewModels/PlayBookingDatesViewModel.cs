using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
	[Serializable]
	public abstract class PlayBookingDatesViewModel
	{
		public DateTime BookingDate { get; set; }
		public TimeOnly StartTime { get; set; }
		public TimeOnly EndTime { get; set; }
	}
}
