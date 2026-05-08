using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;

public class Attribute : IAttribute
{
    public string? Name { get; set; }
    public string? Value { get; set; }
    public object? ValueAsObject { get; set; }
    public string? AttributeType { get; set; }
    public int Sequence { get; set; }
}
