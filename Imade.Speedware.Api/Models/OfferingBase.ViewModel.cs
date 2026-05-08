using System.Text.Json.Serialization;

namespace Imade.Speedware.Api.Models;


public partial class OfferingBase
{
    public int OfferingBaseId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public int CategoryId { get; set; }
    public int DepartmentId { get; set; }
    public string? Department { get; set; }
    public string? SubjectName { get; set; }
    public int SubjectId { get; set; }
    public string? SubjectAreaName { get; set; }
    public int SubjectAreaId { get; set; }
    public List<int> TeacherIds { get; set; } = [];

    [JsonPropertyName("Image")]
    public Blob? Blob { get; set; }
    public IEnumerable<Offering> Offerings { get; set; } = [];
    public IEnumerable<Attribute> Attributes { get; set; } = [];
    public string? CatalogueUrl { get; set; }

}
