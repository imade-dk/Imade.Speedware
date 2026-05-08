namespace Imade.Speedware.Api.Models;


public partial class PlayBookingDates
{
    public DateTime BookingDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public IEnumerable<PlayBookingTimeSlot> Resources { get; set; } = [];
}
