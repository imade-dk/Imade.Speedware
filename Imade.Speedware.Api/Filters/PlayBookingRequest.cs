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
			unchecked
			{
				int hash = Core.HashHelper.FnvSeed;
				hash = Core.HashHelper.HashCollection(hash, BookingTypeIds);
				hash = Core.HashHelper.HashCollection(hash, TeacherIds);
				hash = Core.HashHelper.HashCollection(hash, RoomIds);
				hash = Core.HashHelper.HashCollection(hash, CourseSchoolIds);
				hash = Core.HashHelper.HashValue(hash, BookingId);
				hash = Core.HashHelper.HashValue(hash, DateFrom);
				return hash;
			}
		}
	}
}
