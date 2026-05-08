namespace Imade.Speedware.Api.Models;

public partial class Cancellation
{
    public int BookingId { get; set; }
    public DateTime Date { get; set; }
    public string? Weekday { get; set; }
    public string? Time { get; set; }
    public int TeacherId { get; set; }
    public string? TeacherInitials { get; set; }
    public string? TeacherFullName { get; set; }
    public string? WhoOrWhat { get; set; }
    public string? NewTime { get; set; }
    public DateTime NewDate { get; set; }
    public bool ToBeRescheduled { get; set; }
}
