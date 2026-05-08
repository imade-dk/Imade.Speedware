using System.Text.Json.Serialization;
using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;

public partial class Course: IBlobs
{
    public int CouseId { get; set; }
    [JsonPropertyName("Course")]
    public string? Name { get; set; }
    public int CategoriId { get; set; }
    public string? Categori { get; set; }
    public string? Text { get; set; }
    public string? Description { get; set; }
    public int SubjectCodeId { get; set; }
    public int SubjectCode { get; set; }
    public string? Subject { get; set; }
    public bool Active { get; set; } = true;
    public int OnWaitingList { get; set; }
    public IEnumerable<CoursesSubCategory> SubCategories { get; set; } = [];
    public IEnumerable<Blob> Blobs { get; set; } = [];
    public IEnumerable<Attribute> Attributes { get; set; } = [];
    public IEnumerable<int> AvailableAtSchools { get; set; } = [];
    public IEnumerable<int> TeacherIds { get; set; } = [];

}
