using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
	[Serializable]
	public abstract class PlayBookingTimeSlotViewModel
	{
		public int MasterResourceId { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
	}
}
