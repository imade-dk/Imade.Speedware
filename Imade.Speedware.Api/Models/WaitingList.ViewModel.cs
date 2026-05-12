namespace Imade.Speedware.Api.Models;

public partial class WaitingList
{
    public int WaitingListId { get; set; }
    public int StudentId { get; set; }
    public int WaitingListCourseId { get; set; }
    public DateTime AddedAt { get; set; }
}
