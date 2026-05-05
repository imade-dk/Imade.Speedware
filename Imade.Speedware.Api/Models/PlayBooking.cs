using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models
{
	public class PlayBooking : SpeedwareViewModels.PlayBookingViewModel
	{
		public string BookingTypeName { get; set; }
		public PlayBookingDate BookingDate { get; set; }
	}
}
