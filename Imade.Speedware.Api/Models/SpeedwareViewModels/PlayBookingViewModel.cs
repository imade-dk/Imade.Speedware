using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
	[Serializable]
	public abstract class PlayBookingViewModel
	{
		public int BookingId { get; set; }
		public int BookingTypeId { get; set; }
		public int BookingTypeType { get; set; }
		public string SchoolName { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsEnsemble { get; set; }
		public string CourseName { get; set; }
		public string BookingTypeColor { get; set; }
		public DateTime NextTimeSlotDate { get; set; }
		public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
		public IEnumerable<PlayBookingTimeSlot> TeacherAndRoomOnNextTimeSlot { get; set; } = new List<PlayBookingTimeSlot>();
		public IEnumerable<PlayBookingDate> TimeSlots { get; set; } = new List<PlayBookingDate>();

	}
}
