using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
	[Serializable]
	public abstract class PlayBookingTypeViewModel
	{
		public int BookingTypeId { get; set; }
		public string Name { get; set; }
		public BookingV2TypeType Type { get; set; }
		public bool IsActive { get; set; }
		public string Color { get; set; }
	}
}
