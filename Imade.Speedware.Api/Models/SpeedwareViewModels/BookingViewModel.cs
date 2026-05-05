using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
    [Serializable]
    public abstract class BookingViewModel
    {
		public int BookingId { get; set; }
        public int BookingTypeId { get; set; }
        public string Title { get; set; }
        public string StudentComment { get; set; }
        public string TeacherName { get; set; }
        public string School { get; set; }
        public IEnumerable<int> PublishTypeIds { get; set; }
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
        public IEnumerable<int> RoomIds { get; set; }
        public int TeacherId { get; set; }
        public int BookingImageID { get; set; }
		public DateTime StartDate { get; set; }
		public string ExternalId { get; set; }
        public IEnumerable<BookingDates> BookingDates { get; set; } = new List<BookingDates>();
        public IEnumerable<Blob> Blobs { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
	}
}
