using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;

public partial class Teacher : ISpeedwareModel, IBlob
{
    public string FullName
    {
        get { return $"{Name} {Surname}"; }
    }
    public List<Course> Courses { get; set; } = [];
}
