namespace Imade.Speedware.Api.Models
{
	public partial class PlayBooking 
	{
        public PlayBooking(PlayBooking source)
        {
            BookingId = source.BookingId;
            BookingTypeId = source.BookingTypeId;
            BookingTypeType = source.BookingTypeType;
            SchoolName = source.SchoolName;
            Title = source.Title;
            Description = source.Description;
            IsEnsemble = source.IsEnsemble;
            CourseName = source.CourseName;
            BookingTypeColor = source.BookingTypeColor;
            NextTimeSlotDate = source.NextTimeSlotDate;
            Attributes = source.Attributes;
            TeacherAndRoomOnNextTimeSlot = source.TeacherAndRoomOnNextTimeSlot;
            TimeSlots = source.TimeSlots;
            Blob = source.Blob;
            CatalogueUrl = source.CatalogueUrl;
            BookingTypeName = source.BookingTypeName;
            BookingDate = source.BookingDate;
        }
        public string? BookingTypeName { get; set; }
		public PlayBookingDate? BookingDate { get; set; }
	}
}
