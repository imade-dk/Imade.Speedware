namespace Imade.Speedware.Api.Models;

public class SimpleNode
{
    public int TreeID { get; set; }
    public string? NodeName { get; set; }
    public int ParentID { get; set; }
    public bool Active { get; set; }
    public bool ParentActive { get; set; }
    public IEnumerable<Node> ChildNodes { get; set; } = [];
    public IEnumerable<TreeCourse> Courses { get; set; } = [];
}
