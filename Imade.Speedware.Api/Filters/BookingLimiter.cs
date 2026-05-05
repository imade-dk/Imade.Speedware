using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Filters
{
    public class BookingLimiter : Interfaces.ILimiter
    {        /// <summary>
			 /// Required
			 /// Filter using of type
			 /// </summary>
		public IEnumerable<int> BookingTypeIds { get; set; }
		/// <summary>
		/// Filter using of type
		/// </summary>
		public IEnumerable<int> PublishTypeIds { get; set; }
		/// <summary>
		/// Filter using of type
		/// </summary>
		public IEnumerable<int> RoomIds { get; set; }
		/// <summary>
		/// Filter using equals
		/// </summary>
		public int? BookingId { get; set; }
		/// <summary>
		/// Filter using gt and eq
		/// </summary>
		public DateTime? DateFrom { get; set; }
		/// <summary>
		/// Filter using equals
		/// </summary>
		public string ExternalId { get; set; }
		/// <summary>
		/// Filter using contains
		/// String length: inclusive between 1 and 20
		/// </summary>
		public string TeacherName { get; set; }
        /// <summary>
        /// Range: inclusive between 0 and 500, default 10
        /// </summary>
        public int Take { get; set; } = 10;
        /// <summary>
        /// Range: inclusive between 0 and 2147483647, default 0
        /// </summary>
        public int Skip { get; set; } = 0;
        /// <summary>
        /// Available fields StartDate, TeacherName, BookingTypeId, School
        /// </summary>
        public string Sort { get; set; } = Core.Sorting.BookingsBy.StartDate.ToString();

        public override int GetHashCode()
        {
            // Overflow is fine, just wrap
            unchecked
            {
                int hash = (int)2166136261;
                if (BookingTypeIds is not null)
                    hash = (hash * 16777619) ^ string.Join(",", BookingTypeIds.Select(x => x.ToString()).ToArray()).GetHashCode();
                if (PublishTypeIds is not null)
                    hash = (hash * 16777619) ^ string.Join(",", PublishTypeIds.Select(x => x.ToString()).ToArray()).GetHashCode();
                if (RoomIds is not null)
                    hash = (hash * 16777619) ^ string.Join(",", RoomIds.Select(x => x.ToString()).ToArray()).GetHashCode();
                if (BookingId.HasValue)
                    hash = (hash * 16777619) ^ BookingId.Value.GetHashCode();
                if (DateFrom.HasValue)
                    hash = (hash * 16777619) ^ DateFrom.Value.GetHashCode();
                if (!string.IsNullOrWhiteSpace(TeacherName))
                    hash = (hash * 16777619) ^ TeacherName.GetHashCode();

                hash = (hash * 16777619) ^ Take.GetHashCode();
                hash = (hash * 16777619) ^ Skip.GetHashCode();
                hash = (hash * 16777619) ^ Sort.GetHashCode();

                return hash;
            }
        }
    }
}
