using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imade.Speedware.Api.Filters
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
        [Range(0, 500)]
        public int Take { get; set; } = 10;
        /// <summary>
        /// Range: inclusive between 0 and 2147483647, default 0
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Skip { get; set; } = 0;
        /// <summary>
        /// Available fields StartDate, TeacherName, BookingTypeId, School
        /// </summary>
        public string Sort { get; set; } = Core.Sorting.BookingsBy.StartDate.ToString();

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = Core.HashHelper.FnvSeed;
                hash = Core.HashHelper.HashCollection(hash, BookingTypeIds);
                hash = Core.HashHelper.HashCollection(hash, PublishTypeIds);
                hash = Core.HashHelper.HashCollection(hash, RoomIds);
                hash = Core.HashHelper.HashValue(hash, BookingId);
                hash = Core.HashHelper.HashValue(hash, DateFrom);
                hash = Core.HashHelper.HashString(hash, TeacherName);
                hash = (hash * 16777619) ^ Take.GetHashCode();
                hash = (hash * 16777619) ^ Skip.GetHashCode();
                hash = (hash * 16777619) ^ Sort.GetHashCode();
                return hash;
            }
        }
    }
}
