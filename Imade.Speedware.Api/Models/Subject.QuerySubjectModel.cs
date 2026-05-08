namespace Imade.Speedware.Api.Models;

public partial class Subject
{
    public int SubjectId { get; set; }
    public string? Name { get; set; }
    public int SubjectAreaId { get; set; }
    public bool IsActive { get; set; }
}
