namespace Imade.Speedware.Api.Models;

public partial class PlayBooking
{
    public int BookingId { get; set; }
    public int BookingTypeId { get; set; }
    public int BookingTypeType { get; set; }
    public string? SchoolName { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsEnsemble { get; set; }
    public string? CourseName { get; set; }
    public string? BookingTypeColor { get; set; }
    public DateTime NextTimeSlotDate { get; set; }
    public IEnumerable<Attribute> Attributes { get; set; } = [];
    public IEnumerable<PlayBookingTimeSlot> TeacherAndRoomOnNextTimeSlot { get; set; } = [];
    public IEnumerable<PlayBookingDate> TimeSlots { get; set; } = [];
    public string? ImageUniqueBlobId { get; set; }
    public string? CatalogueUrl { get; set; }
}
