namespace Imade.Speedware.Api.Models;


public partial class BookingDates
{
    public int BookingDateId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public IEnumerable<Attribute> Attributes { get; set; } = [];
}
