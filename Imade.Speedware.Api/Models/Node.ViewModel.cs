namespace Imade.Speedware.Api.Models;

public partial class Node
{
    public int TreeID { get; set; }
    public string? NodeName { get; set; }
    public string? NodeDescription { get; set; }
    public int ParentID { get; set; }
    public string? Position { get; set; }
    public int TreeTypeID { get; set; }
    public int RessourceID { get; set; }
    public int RessourceTypeID { get; set; }
    public bool Active { get; set; }
    public bool ParentActive { get; set; }
    public IEnumerable<Node> ChildNodes { get; set; } = [];
    public IEnumerable<TreeCourse> Courses { get; set; } = [];
    public Blob? Blob { get; set; }
}
