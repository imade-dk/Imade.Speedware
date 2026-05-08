namespace Imade.Speedware.Api.Models;

public partial class SubjectArea
{
    public int SubjectAreaId { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public SubjectAreaRegistrationLink RegistrationLink { get; set; }
    public IEnumerable<Subject> Subjects { get; set; } = [];
}
