using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Filters
{
	public class PlayBookingRequest: Interfaces.ILimiter
	{
		public IEnumerable<int> BookingTypeIds { get; set; }
		public IEnumerable<int> TeacherIds { get; set; }
		public IEnumerable<int> RoomIds { get; set; }
		public IEnumerable<int> CourseSchoolIds { get; set; }
		public int? BookingId { get; set; }
		public DateTime? DateFrom { get; set; }

		public override int GetHashCode()
		{
			// Overflow is fine, just wrap
			unchecked
			{
				int hash = (int)2166136261;
				if (BookingTypeIds is not null)
					hash = (hash * 16777619) ^ string.Join(",", BookingTypeIds.Select(x => x.ToString()).ToArray()).GetHashCode();
				if (TeacherIds is not null)
					hash = (hash * 16777619) ^ string.Join(",", TeacherIds.Select(x => x.ToString()).ToArray()).GetHashCode();
				if (RoomIds is not null)
					hash = (hash * 16777619) ^ string.Join(",", RoomIds.Select(x => x.ToString()).ToArray()).GetHashCode();
				if (CourseSchoolIds is not null)
					hash = (hash * 16777619) ^ string.Join(",", CourseSchoolIds.Select(x => x.ToString()).ToArray()).GetHashCode();
				if (BookingId.HasValue)
					hash = (hash * 16777619) ^ BookingId.Value.GetHashCode();
				if (DateFrom.HasValue)
					hash = (hash * 16777619) ^ DateFrom.Value.GetHashCode();
				return hash;
			}
		}
	}
}
